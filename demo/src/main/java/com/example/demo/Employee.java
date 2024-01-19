package com.example.demo;



import java.time.LocalDate;

public class Employee {

    private int employeeId;
    private String firstName;
    private String lastName;
    private LocalDate dateOfBirth;
    private String department;

    private Payroll payroll;


    public Employee(int employeeId, String firstName, String lastName, LocalDate dateOfBirth, String department) {

        this.employeeId = employeeId;
        this.firstName = firstName;
        this.lastName = lastName;
        this.dateOfBirth = dateOfBirth;
        this.department = department;
        this.payroll = new Payroll(employeeId,0.0,0);

    }

    public void setPayroll(Payroll payroll1){
        payroll = payroll1;
    }



    public int getEmployeeId() {
        return employeeId;
    }



    @Override
    public String toString() {
        return "Employee{" +
                "employeeId='" + employeeId + '\n' +
                ", firstName='" + firstName + '\n' +
                ", lastName='" + lastName + '\n' +
                ", dateOfBirth=" + dateOfBirth + '\n' +
                ", department='" + department + '\n' +
                ", payroll=" + payroll.toString() + '\n'+
                '}';
    }
}

