package com.example.demo;

import java.io.*;
import java.util.ArrayList;
import java.util.List;

public class Payroll {

    private int employeeId;
    private double salary;
    private int hoursWorked;
    private static final String PAYROLL_FILE = "payroll_data.ser";
    public Payroll(int employeeId, double salary, int hoursWorked) {
        this.employeeId = employeeId;
        this.salary = salary;
        this.hoursWorked = hoursWorked;
    }


    public double calculateGrossSalary() {
        return salary * hoursWorked;
    }
    public double calculateOvertimePay() {
        // Assume overtime rate is 1.5 times the regular hourly rate
        int regularHours = 40;
        if (hoursWorked > regularHours) {
            int overtimeHours = hoursWorked - regularHours;
            return overtimeHours * 1.5 * salary;
        } else {
            return 0;
        }
    }
    public double calculateNetSalary() {
        // Assume a simple tax deduction for demonstration purposes
        double taxRate = 0.2; // 20% tax rate
        double grossSalary = calculateGrossSalary();
        double taxAmount = grossSalary * taxRate;
        return grossSalary - taxAmount;
    }



    @Override
    public String toString(){
        String s = "";
        s = s + "Employee Id : " + employeeId;
        s = s + "\nHours Worked : " + hoursWorked;
        s = s + "\nSalary : " + salary;
        s = s + "\nGross Salary : " + calculateGrossSalary();
        s = s + "\nOvertime Pay : " + calculateOvertimePay();
        s = s + "\nNet Salary : " + calculateNetSalary();
        return s;
    }
    public static void savePayrollData(List<Payroll> payrollList) {
        try (ObjectOutputStream oos = new ObjectOutputStream(new FileOutputStream(PAYROLL_FILE))) {
            oos.writeObject(payrollList);
            System.out.println("Payroll data saved successfully.");
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    // Deserialize payroll data
    public static List<Payroll> loadPayrollData() {
        try (ObjectInputStream ois = new ObjectInputStream(new FileInputStream(PAYROLL_FILE))) {
            return (List<Payroll>) ois.readObject();
        } catch (IOException | ClassNotFoundException e) {
            // Handle the exception, e.g., file not found on the first run
            e.printStackTrace();
            return new ArrayList<>();
        }
    }
}
