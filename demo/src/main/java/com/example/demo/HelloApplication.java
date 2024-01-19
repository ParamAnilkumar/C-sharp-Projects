package com.example.demo;

import javafx.application.Application;
import javafx.geometry.Insets;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.layout.BorderPane;
import javafx.scene.layout.GridPane;
import javafx.stage.Stage;

import java.time.LocalDate;
import java.util.Optional;

public class HelloApplication extends Application {
    private EmployeeManager employeeManager = new EmployeeManager();

    public static void main(String[] args) {
        launch(args);
    }

    @Override
    public void start(Stage primaryStage) {

        primaryStage.setTitle("Employee Management System");

        BorderPane borderPane = new BorderPane();
        Scene scene = new Scene(borderPane, 800, 600);


        GridPane employeeGrid = new GridPane();
        employeeGrid.setHgap(10);
        employeeGrid.setVgap(10);
        employeeGrid.setPadding(new Insets(10, 10, 10, 10));
        Label txt = new Label();

        Label firstNameLabel = new Label("First Name:");
        TextField firstNameField = new TextField();

        Label lastNameLabel = new Label("Last Name:");
        TextField lastNameField = new TextField();

        Label dobLabel = new Label("Date of Birth:");
        DatePicker dobPicker = new DatePicker();

        Label departmentLabel = new Label("Department:");
        TextField departmentField = new TextField();

        Label employeeIdLabel = new Label("Employee ID:");
        TextField employeeIdField = new TextField();





        Button addEmployeeButton = new Button("Add Employee");

       addEmployeeButton.setOnAction(e -> employeeManager.addEmployee(
                Integer.parseInt(employeeIdField.getText()),
                firstNameField.getText(),
                lastNameField.getText(),
                dobPicker.getValue(),
                departmentField.getText()));








        Button deleteEmployeeButton = new Button("Delete Employee");
        deleteEmployeeButton.setOnAction(e -> promptDeleteEmployee());

        Button updatePayStuff = new Button("Update PayStuff");
        updatePayStuff.setOnAction(e -> updatePaystuff());

        Label viewLabel = new Label("Id : ");
        TextField idViewField = new TextField();
        Button viewEmployeeButton = new Button("View Perticular Employee");

        Button updateEmp = new Button("Update Employee");
        updateEmp.setOnAction(e->promptupdateEmployee());







        employeeGrid.add(firstNameLabel, 0, 0);
        employeeGrid.add(firstNameField, 1, 0);
        employeeGrid.add(lastNameLabel, 0, 1);
        employeeGrid.add(lastNameField, 1, 1);
        employeeGrid.add(dobLabel, 0, 2);
        employeeGrid.add(dobPicker, 1, 2);
        employeeGrid.add(departmentLabel, 0, 3);
        employeeGrid.add(departmentField, 1, 3);
        employeeGrid.add(employeeIdLabel, 0, 4);
        employeeGrid.add(employeeIdField, 1, 4);
        employeeGrid.add(addEmployeeButton, 0, 5, 2, 1);
        employeeGrid.add(deleteEmployeeButton,0,7);
        employeeGrid.add(viewLabel,0,18);
        employeeGrid.add(idViewField,1,18);
        employeeGrid.add(viewEmployeeButton,0,19);
        employeeGrid.add(updatePayStuff,0,22);
        employeeGrid.add(updateEmp,0,24);


        TextArea employeeDetailsArea = new TextArea();
        employeeDetailsArea.setEditable(false);

        viewEmployeeButton.setOnAction(e -> employeeDetailsArea.setText(employeeManager.viewEmployee(Integer.parseInt(idViewField.getText()))));

        Button viewAllEmployeesButton = new Button("View All Employees");
        viewAllEmployeesButton.setOnAction(e -> employeeDetailsArea.setText(employeeManager.viewAllEmployee()));


        borderPane.setLeft(employeeGrid);
        borderPane.setRight(employeeDetailsArea);

        borderPane.setBottom(viewAllEmployeesButton);

        primaryStage.setScene(scene);
        primaryStage.show();
    }


    private void updateEmployee(int id, String firstName, String lastName, LocalDate dateOfBirth, String department){
        employeeManager.updateEmployee(id, firstName, lastName, dateOfBirth, department);
    }

    private void updatePayroll(int id, double salary, int hoursWorked){
        employeeManager.updatePayroll(id,salary,hoursWorked);
    }
        private void deleteEmployee(int id){
        employeeManager.deleteEmployee(id);
    }
    private void promptDeleteEmployee() {
        TextInputDialog dialog = new TextInputDialog();
        dialog.setTitle("Delete Employee");
        dialog.setHeaderText("Enter Employee ID to delete:");
        dialog.setContentText("Employee ID:");

        Optional<String> result = dialog.showAndWait();
        result.ifPresent(id -> deleteEmployee(Integer.parseInt(id)));
    }
    private void updatePaystuff(){
        TextInputDialog dialog = new TextInputDialog();
        dialog.setTitle("Payroll");
        dialog.setHeaderText("Enter Id to Update Payroll Data");

        Label idLabel = new Label("Id : ");
        TextField idField = new TextField();
        Label salaryLabel = new Label("Salary : ");
        TextField salaryField = new TextField();
        Label hoursLabel = new Label("Hours Worked : ");
        TextField hoursField = new TextField();
        GridPane grid = new GridPane();
        grid.add(idLabel,0,0);
        grid.add(idField,1,0);
        grid.add(salaryLabel,0,1);
        grid.add(salaryField,1,1);
        grid.add(hoursLabel,0,2);
        grid.add(hoursField,1,2);
        dialog.getDialogPane().setContent(grid);
        Optional<String> result = dialog.showAndWait();
        if(result.isPresent()) {
            // Process the entered data
            try {
                int id = Integer.parseInt(idField.getText());
                double salary = Double.parseDouble(salaryField.getText());
                int hoursWorked = Integer.parseInt(hoursField.getText());

                // Call your updatePayroll method with the entered data
                updatePayroll(id, salary, hoursWorked);
            } catch (NumberFormatException e) {
                // Handle invalid input
                System.out.println("Invalid input. Please enter valid numbers.");
            }
        }
    }
    private void promptupdateEmployee(){
        TextInputDialog dialog = new TextInputDialog();
        dialog.setTitle("Update Employee");
        dialog.setHeaderText("Enter Details to Update Employee with the id " );

        Label idLabel = new Label("Enter id : ");
        TextField idField = new TextField();

        Label firstNameLabel = new Label("First Name:");
        TextField firstNameField = new TextField();

        Label lastNameLabel = new Label("Last Name:");
        TextField lastNameField = new TextField();

        Label dobLabel = new Label("Date of Birth:");
        DatePicker dobPicker = new DatePicker();

        Label departmentLabel = new Label("Department:");
        TextField departmentField = new TextField();

        GridPane employeeGrid = new GridPane();
        employeeGrid.add(firstNameLabel, 0, 0);
        employeeGrid.add(firstNameField, 1, 0);
        employeeGrid.add(lastNameLabel, 0, 1);
        employeeGrid.add(lastNameField, 1, 1);
        employeeGrid.add(dobLabel, 0, 2);
        employeeGrid.add(dobPicker, 1, 2);
        employeeGrid.add(departmentLabel, 0, 3);
        employeeGrid.add(departmentField, 1, 3);
        employeeGrid.add(idLabel, 0, 4);
        employeeGrid.add(idField, 1, 4);

        dialog.getDialogPane().setContent(employeeGrid);
        Optional<String> result = dialog.showAndWait();

        if(result.isPresent()){
            int id = Integer.parseInt(idField.getText());
            String fname = firstNameField.getText();
            String lname = lastNameField.getText();
            LocalDate DateOfBday = dobPicker.getValue();
            String d = departmentField.getText();
            updateEmployee(id,fname,lname,DateOfBday,d);
        }

    }


}
