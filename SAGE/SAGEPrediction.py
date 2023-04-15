# Caleb Smith
# 04/15/2023
import neuralnetbuilder as dlb
import pyodbc as dbc
import numpy as np
import matplotlib.pyplot as plt
import SAGEDevelopment as SAGE

def main(): 
    # Connect to the SQL Server database
    connection_string = r'DRIVER={ODBC Driver 17 for SQL Server};SERVER=(localdb)\MSSQLLocalDB;DATABASE=C:\Users\caleb\Documents\GitHub\StockPicker\StockData\Stocks.mdf;Trusted_Connection=yes;'
    connection = dbc.connect(connection_string)

    # Execute queries
    cursor = connection.cursor()
    cursor.execute('SELECT * FROM StocksCurrent')
    records = cursor.fetchall()

    neuralnet = SAGE.build_net()
    bias_values, weight_values = SAGE.load_model()
    neuralnet.set_model_data(bias_values, weight_values)

    for row in records:
        if None in row:
            continue 
        gains = neuralnet.predict([round(row[7] / 100, 2), round(row[9] / 100, 2), round(row[10] / 100, 2)])[0]
        gains = gains * 100
        cursor.execute('UPDATE StocksCurrent SET [Predicted Gains] = ? WHERE Ticker = ?', (gains, row[0]))
        cursor.commit()

    cursor.close()
    connection.close()


        
if __name__ == "__main__":
    main()