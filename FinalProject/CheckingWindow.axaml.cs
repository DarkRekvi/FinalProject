using System;
using System.Collections;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MySql.Data.MySqlClient;

namespace FinalProject;

public partial class CheckingWindow : Window
{
    private string _sql = "select check_id, employee, Employees.employee_name, department, Departments.department_name, area, Areas.area_name, check_date, result, Results.result_name from Checkings " +
                          "join Employees on Checkings.employee = Employees.id " +
                          "join Departments on Checkings.department = Departments.id " +
                          "join Areas on Checkings.area = Areas.id " +
                          "join Results on Checkings.result = Results.id;";
    public DB _Db = new DB();
    private List<Checking> _checkings;
    
    public CheckingWindow()
    {
        _Db.CloseConnection();
        InitializeComponent();
        ShowTable();
    }

    public void ShowTable()
    {
        _Db.OpenConnection();
        MySqlConnection _connection = _Db.GetConnection();
        _checkings = new List<Checking>();
        MySqlCommand command = new MySqlCommand(_sql,_connection);
        MySqlDataReader reader = command.ExecuteReader();

        while (reader.Read() && reader.HasRows)
        {
            var current = new Checking()
            {
                Checking_ID = reader.GetInt32("check_id"),
                Employee = reader.GetString("employee_name"),
                Department = reader.GetString("department_name"),
                Area = reader.GetString("area_name"),
                Checking_Date = reader.GetDateTime("check_date"),
                Result = reader.GetString("result_name")
            };
            _checkings.Add(current);
        }
        _Db.CloseConnection();
        CheckGrid.ItemsSource = _checkings;
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        MainWindow win = new MainWindow();
        win.Show();
        this.Close();
    }

    private void AddChecking(object? sender, RoutedEventArgs e)
    {
        CheckingAddWindow win = new CheckingAddWindow();
        win.Show();
        this.Close();
    }

    private void Delete(object? sender, RoutedEventArgs e)
    {
    }

    private void Editing(object? sender, RoutedEventArgs e)
    {
        CheckingEditWindow win = new CheckingEditWindow();
        win.Show();
        this.Close();
    }
}