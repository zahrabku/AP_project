using project.back.controller;
using project.back.domain.entity;
using project.back.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        FileUtils fileinfo = new FileUtils();

        private void boombutton_Click(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            while (flag == false)
            {
                try
                {
                    // saving data in userInfo
                    UserInfo userInfo = new UserInfo();
                    userInfo.Name = solve_firstNameTextBox.Text;
                    userInfo.LastName = solve_LastNameTextBox.Text;
                    userInfo.Age = Convert.ToInt32(solve_AgeTextBox.Text);
                    userInfo.City = solve_CityTextBox.Text;
                    //send data to equation solver

                    double[,] coeff3 = new double[3, 4];
                    double[,] coeff2 = new double[2, 3];

                    Answer ansr;

                    if (a1.Text == a2.Text && a2.Text == a3.Text && a1.Text == a3.Text && b1.Text == b2.Text && b2.Text == b3.Text && b1.Text == b3.Text && c1.Text == c2.Text && c2.Text == c3.Text && c1.Text == c3.Text && EQQuant3 == EQQuant2 && EQQuant1 == EQQuant2 && EQQuant3 == EQQuant1)
                    {
                        Equation equation = new Equation(X1.Text, Y1.Text, Z1.Text,Convert.ToDouble (a1.Text),0.0 ,0.0 , Convert.ToDouble(b1.Text), 0.0, 0.0, Convert.ToDouble(c1.Text), 0.0, 0.0, Convert.ToDouble(EQQuant1.Text), 0.0, 0.0);
                        ansr = null;
                        userInfo.Answer = ansr;
                        userInfo.Equation = equation;
                    }
                    else {
                        if (a3.Text == "0" && b3.Text == "0" && c3.Text == "0" && EQQuant3.Text == "0")
                        {
                            coeff2[0, 0] = Convert.ToDouble(a1.Text);
                            coeff2[1, 0] = Convert.ToDouble(a2.Text);
                            coeff2[0, 1] = Convert.ToDouble(b1.Text);
                            coeff2[1, 1] = Convert.ToDouble(b2.Text);
                            coeff2[0, 2] = Convert.ToDouble(EQQuant1.Text);
                            coeff2[1, 2] = Convert.ToDouble(EQQuant2.Text);

                            ansr = EquationSolver2.findSolution(coeff2);
                            userInfo.Answer = ansr;

                            //processing equation
                            Equation equation = new Equation(X1.Text, Y1.Text, Z1.Text, coeff2[0, 0], coeff2[1, 0], 0.0, coeff2[0, 1], coeff2[1, 1], 0.0, 0.0, 0.0, 0.0, coeff2[0, 2], coeff2[1, 2], 0.0);
                            userInfo.Equation = equation;
                        }
                        else
                        {
                            coeff3[0, 0] = Convert.ToDouble(a1.Text);
                            coeff3[1, 0] = Convert.ToDouble(a2.Text);
                            coeff3[2, 0] = Convert.ToDouble(a3.Text);
                            coeff3[0, 1] = Convert.ToDouble(b1.Text);
                            coeff3[1, 1] = Convert.ToDouble(b2.Text);
                            coeff3[2, 1] = Convert.ToDouble(b3.Text);
                            coeff3[0, 2] = Convert.ToDouble(c1.Text);
                            coeff3[1, 2] = Convert.ToDouble(c2.Text);
                            coeff3[2, 2] = Convert.ToDouble(c3.Text);
                            coeff3[0, 3] = Convert.ToDouble(EQQuant1.Text);
                            coeff3[1, 3] = Convert.ToDouble(EQQuant2.Text);
                            coeff3[2, 3] = Convert.ToDouble(EQQuant3.Text);

                            ansr = EquationSolver3.findSolution(coeff3);
                            userInfo.Answer = ansr;

                            //processing equation 
                            Equation equation = new Equation(X1.Text, Y1.Text, Z1.Text, coeff3[0, 0], coeff3[1, 0], coeff3[2, 0], coeff3[0, 1], coeff3[1, 1], coeff3[2, 1], coeff3[0, 2], coeff3[1, 2], coeff3[2, 2], coeff3[0, 3], coeff3[1, 3], coeff3[2, 3]);
                            userInfo.Equation = equation;
                        }
                        fileinfo.writeInfo(userInfo);
                        //showing result
                        solve_AnswerTextBox.Text = $"x={ansr.Answer1}   y={ansr.Answer2}   z={ansr.Answer3}   {ansr.Answer4}";
                    }
                }
                catch (Exception ex)
                {
                    string messageBoxText = "You might not enter some data or they're not in a correct format ; please try again.";
                    string caption = "Exception";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Warning;

                    MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
                    if (result == MessageBoxResult.OK)
                    {
                        break;
                    }
                }
            }
        }

        private void query_bottun_Click(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            while (flag == false)
            {
                try
                {
                    queryUtils.QueryName = query_NameTextBox.Text;
                    queryUtils.QueryLastName = query_LastNameTextBox.Text;
                    queryUtils.QueryCity = query_CityTextBox.Text;
                    queryUtils.QueryAgeGT = query_AgeGTTextBox.Text;
                    queryUtils.QueryAgeLT = query_AgeLTtextBox.Text;
                    queryUtils.QueryEquation = query_equationTextBox.Text;
                    queryUtils.QueryResult = query_AnswerTextBox.Text;
                    List<string> fileNames = query.queryMethod();
                    foreach (string fnm in fileNames)
                    {
                        query_ResultTextBox.Text += query.GetFileText(fnm);
                    }
                    flag = true;
                }
                catch (Exception ex)
                {
                    string messageBoxText = "You might not enter some data or they're not in a correct format ; please try again.";
                    string caption = "Exception";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Warning;

                    MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
                    if (result == MessageBoxResult.OK)
                    {
                        break;
                    }
                }
            }

        }
    }
}
