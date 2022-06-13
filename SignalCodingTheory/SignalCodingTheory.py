import numpy as np
import matplotlib.pyplot as plt
from math import pi, sin, cos, log, sqrt, fabs
from matplotlib.ticker import MultipleLocator as ML
from matplotlib.ticker import AutoMinorLocator as AML

def function(x):
    return sin(x)**3

def function_with_error(x, n, k_0):
    return function(x) + cos(n*x) / sqrt(log(n)) * (x-(k_0+0.5)*pi/n) / fabs(x-(k_0+0.5)*pi/n)

def function_s(x, n, k, k_0):
    return (-1)**k * sin(n*x) / (n*x-k*pi)

def operator_L(x, n, k_0):
    L = 0
    for k in range(n+1):
        L += function_s(x, n, k, k_0) * function_with_error(k*pi/n, n, k_0)
    return L

def operator_A(x, n, k_0):
    A = 0
    for k in range(1, n+1):
        A += (function_s(x, n, k-1, k_0) + function_s(x, n, k, k_0)) * function_with_error(k*pi/n, n, k_0)
    return 0.5*A

def main():
    k_0=35
    n=100
    value_x = []
    value_f = []
    value_f_with_error = []
    value_operator_L  = []
    value_operator_A  = []

    for value in np.linspace(0, pi, num=n):
        value_x.append(value)
        value_f.append(function(value))
        value_f_with_error.append(function_with_error(value, n, k_0))
     
    for value in value_x[1:n-1]:
        value_operator_L.append(operator_L(value, n, k_0))
        value_operator_A.append(operator_A(value, n, k_0))
    
    fig = plt.figure(figsize=(10, 5))
    ax = fig.add_subplot(111)
    ax.plot(value_x, value_f, label = 'The function f', color = 'blue')
    ax.plot(value_x, value_f_with_error, label = 'The function f with error', color = 'green')
    ax.plot(value_x[1:n-1], value_operator_L, label = 'The operator L', color = 'black')
    ax.plot(value_x[1:n-1], value_operator_A, label = 'The operator A', color = 'red')
    # Change major, minor ticks
    ax.xaxis.set_major_locator(ML(0.5))
    ax.yaxis.set_major_locator(ML(0.5))
    ax.grid(which='major', color='#CCCCCC')
    ax.xaxis.set_minor_locator(AML(2))
    ax.yaxis.set_minor_locator(AML(2))
    ax.grid(which='minor', color='#CCCCCC')
    ax.legend(ncol = 2, edgecolor = '#e0e9ed')
    # Adding labels
    ax.set_xlabel('X-axis', fontweight ='bold')
    ax.set_ylabel('Y-axis', fontweight ='bold')
    plt.show()

if __name__ == "__main__":
    main()
   