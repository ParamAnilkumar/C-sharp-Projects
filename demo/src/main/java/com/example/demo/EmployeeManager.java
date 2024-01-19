package com.example.demo;

import javafx.beans.Observable;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.fxml.FXML;
import javafx.scene.control.TableView;

import java.time.LocalDate;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.List;


public class EmployeeManager {
    @FXML
    private TableView<Employee> employeeTableView;
    private ObservableList<Employee> employeeList = FXCollections.observableArrayList();

    private static final String EMPLOYEE_DATA_FILE = "c:\\t177 SEM 3\\employee_data.ser";


    private int numEmployee;
    private int max;

public EmployeeManager(){
    loadEmployeeData();
}
    public boolean addEmployee(int id,String firstName, String lastName, LocalDate dateOfBirth, String department) {

        if (isEmployeeIdUnique(id)) {
            employeeList.add(new Employee(id, firstName, lastName, dateOfBirth, department));
            System.out.println("Employee Added!");
            numEmployee++;
            saveEmployeeData();
            return true;

        }
        else{
            System.out.println("Duplicate Employee Id");

return false;
        }
    }
    public void updatePayroll(int id, double salary, int hoursWorked){
    Employee e = findEmployee(id);
    e.setPayroll(new Payroll(id,salary,hoursWorked));
    }

    private int findEmployeeIndex(int employeeId) {
        for (int i = 0; i < employeeList.size(); i++) {
            if (employeeList.get(i).getEmployeeId() == employeeId) {
                return i;
            }
        }
        return -1; // Employee not found
    }
    public Employee findEmployee(int id){
     int index = findEmployeeIndex(id);
     return employeeList.get(index);
    }
    public void updateEmployee(int id,String firstName, String lastName, LocalDate dateOfBirth, String department){
        int index = findEmployeeIndex(id);
        if(index != 1){
            employeeList.set(index,new Employee(id,firstName,lastName,dateOfBirth,department));
            System.out.println("Employee Updated");
        }
        else{
            System.out.println("Employee not Found");

        }
    }
    private boolean isEmployeeIdUnique(int employeeId) {
        return employeeList.stream().noneMatch(employee -> employee.getEmployeeId()==employeeId);
    }
    public void deleteEmployee(int id){
        Employee e = findEmployee(id);
        employeeList.remove(e);
        System.out.println("Employee Deleted!");
    }
    public String viewEmployee(int id){
        Employee e = findEmployee(id);
        return e.toString();
    }
    private void saveEmployeeData() {
        try (ObjectOutputStream oos = new ObjectOutputStream(Files.newOutputStream(Paths.get(EMPLOYEE_DATA_FILE)))) {
            oos.writeObject(new ArrayList<>(employeeList));
            System.out.println("Employee data saved successfully.");
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
    private void loadEmployeeData() {
        if (Files.exists(Paths.get(EMPLOYEE_DATA_FILE))) {
            try (ObjectInputStream ois = new ObjectInputStream(Files.newInputStream(Paths.get(EMPLOYEE_DATA_FILE)))) {
                List<Employee> loadedEmployees = (List<Employee>) ois.readObject();
                employeeList.addAll(loadedEmployees);
                System.out.println("Employee data loaded successfully.");
            } catch (IOException | ClassNotFoundException e) {
                e.printStackTrace();
            }
        }
    }
    public String viewAllEmployee() {
        String s = "";
        for (int i = 0; i < employeeList.size(); i++) {
            s += employeeList.get(i).toString() + "\n";
        }
        return s;
    }
}
