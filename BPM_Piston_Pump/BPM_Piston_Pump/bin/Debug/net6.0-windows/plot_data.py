import matplotlib.pyplot as plt
import numpy as np
  
x1 = []
y1 = []
x2 = []
y2 = []
i=0
fs = 500
for line in open('debug_env.txt', 'r'):
    y1.append(float(line.replace(",",".")))
    x1.append(i/fs)
    i+=1
    
i=0;
    
for line in open('debug_work.txt', 'r'):
    y2.append(float(line.replace(",",".")))
    x2.append(i/fs)
    i+=1

plt.title("Content of data.txt")
plt.ylabel("Voltage in V")
plt.xlabel("Time in s")
plt.plot(x1, y1)  
plt.plot(x2, y2) 
plt.show()