# Caleb Smith
# 04/14/2023
import neuralnetbuilder as dlb
import pyodbc as dbc
import numpy as np
import matplotlib.pyplot as plt


def build_net():
    # build neural network using builder class
    neuralnetbuilder = dlb.neuralnetbuilder()
    neuralnetbuilder.set_neural_layers(8, [3, 6, 4, 4, 4, 2, 2, 1], [0, 2, 2, 2, 2, 2, 2, 2])
    neuralnetbuilder.set_learning_rate(.01)
    neuralnet = neuralnetbuilder.build()
    return neuralnet

# Connect to the SQL Server database
connection_string = r'DRIVER={ODBC Driver 17 for SQL Server};SERVER=(localdb)\MSSQLLocalDB;DATABASE=C:\Users\caleb\Documents\GitHub\StockPicker\StockData\Stocks.mdf;Trusted_Connection=yes;'
connection = dbc.connect(connection_string)

# Execute queries
cursor = connection.cursor()
cursor.execute('SELECT * FROM StocksHistoric')

# split test groups
training1data = []
training1targets = []
validation1data = []
validation1targets = []
training2data = []
training2targets = []
validation2data = []
validation2targets = []
training3data = []
training3targets = []
validation3data = []
validation3targets = []
training4data = []
training4targets = []
validation4data = []
validation4targets = []
for row in cursor:
    group_num = np.random.randint(1, 9)
    if group_num == 1:
        target = row[15] / 100
        if target > 1:
            target = 1
        training1data.append([round(row[9] / 100, 2), round(row[11] / 100, 2), round(row[12] / 100, 2)])
        training1targets.append([round(target, 2)])
    elif group_num == 2:
        target = row[15] / 100
        if target > 1:
            target = 1
        validation1data.append([round(row[9] / 100, 2), round(row[11] / 100, 2), round(row[12] / 100, 2)])
        validation1targets.append([round(target, 2)])
    elif group_num == 3:
        target = row[15] / 100
        if target > 1:
            target = 1
        training2data.append([round(row[9] / 100, 2), round(row[11] / 100, 2), round(row[12] / 100, 2)])
        training2targets.append([round(target, 2)])
    elif group_num == 4:
        target = row[15] / 100
        if target > 1:
            target = 1
        validation2data.append([round(row[9] / 100, 2), round(row[11] / 100, 2), round(row[12] / 100, 2)])
        validation2targets.append([round(target, 2)])
    elif group_num == 5:
        target = row[15] / 100
        if target > 1:
            target = 1
        training3data.append([round(row[9] / 100, 2), round(row[11] / 100, 2), round(row[12] / 100, 2)])
        training3targets.append([round(target, 2)])
    elif group_num == 6:
        target = row[15] / 100
        if target > 1:
            target = 1
        validation3data.append([round(row[9] / 100, 2), round(row[11] / 100, 2), round(row[12] / 100, 2)])
        validation3targets.append([round(target, 2)])
    elif group_num == 7:
        target = row[15] / 100
        if target > 1:
            target = 1
        training4data.append([round(row[9] / 100, 2), round(row[11] / 100, 2), round(row[12] / 100, 2)])
        training4targets.append([round(target, 2)])
    else:
        target = row[15] / 100
        if target > 1:
            target = 1
        validation4data.append([round(row[9] / 100, 2), round(row[11] / 100, 2), round(row[12] / 100, 2)])
        validation4targets.append([round(target, 2)])




# Save Model
def save_model(neural_net):
    bias_values, weight_values = neural_net.save_model_data()

    np_bias = np.array(bias_values, dtype=object)
    np_weights = np.array(weight_values, dtype=object)

    np.savez(r"C:\Users\caleb\Documents\GitHub\StockPicker\SAGE\SAGEBiasValues.npz", a=np_bias)
    np.savez(r"C:\Users\caleb\Documents\GitHub\StockPicker\SAGE\SAGEWeightValues.npz", a=np_weights)


# Load Model
def load_model():
    bias_data = np.load(r"C:\Users\caleb\Documents\GitHub\StockPicker\SAGE\SAGEBiasValues.npz", allow_pickle=True)
    weight_data = np.load(r"C:\Users\caleb\Documents\GitHub\StockPicker\SAGE\SAGEWeightValues.npz", allow_pickle=True)

    bias_load = bias_data["a"].tolist()
    weight_load = weight_data["a"].tolist()
    return bias_load, weight_load


def train_net(training_data, training_targets, validation_data, validation_targets):
    neuralnet = build_net()
    neuralnet.train(training_data, training_targets, 10000)

    neuralnet_old = build_net()
    bias_values, weight_values = load_model()
    neuralnet_old.set_model_data(bias_values, weight_values)

    error_new = validate_net(neuralnet, validation_data, validation_targets)
    error_old = validate_net(neuralnet_old, validation_data, validation_targets)

    if error_new < error_old:
        save_model(neuralnet)


def validate_net(neuralnet, validation_data, validation_targets):
    prediction = []
    for i in range(len(validation_data)):
        prediction.append(neuralnet.predict(validation_data[i]))

    error = 0
    for i in range(len(validation_targets)):
        error += neuralnet.mean_squared_error(validation_targets[i], prediction[i])

    return error

validationdata = validation1data + validation2data + validation3data + validation4data
validationtargets = validation1targets + validation2targets + validation3targets + validation4targets
train_net(training1data, training1targets, validationdata, validationtargets)
train_net(training2data, training2targets, validationdata, validationtargets)
train_net(training3data, training3targets, validationdata, validationtargets)
train_net(training4data, training4targets, validationdata, validationtargets)

neuralnet = build_net()
bias_values, weight_values = load_model()
neuralnet.set_model_data(bias_values, weight_values)
print(validate_net(neuralnet, validationdata, validationtargets))

connection.close()