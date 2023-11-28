import matplotlib.pyplot as plt
import numpy as np
  
x = []
y = []
i=0
fs = 500
for line in open('log.csv', 'r'):
    if i!=0:
        y.append(float(line.split(";")[0].replace(",",".")))
        x.append(i/fs)
    i+=1

plt.title("Content of data.txt")
plt.ylabel("Voltage in V")
plt.xlabel("Time in s")
plt.plot(x, y)  
plt.show()