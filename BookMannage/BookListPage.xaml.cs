using BookMannage.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookMannage
{
    /// <summary>
    /// BookListPage.xaml 的交互逻辑
    /// </summary>
    public partial class BookListPage : Page
    {
        public BookListPage()
        {
            InitializeComponent();


            FileHelper fileHelper = new FileHelper();
            var listBook = new List<Book>();
            var data = fileHelper.FileToString("I:\\c#项目\\BookMannage\\BookMannage\\BookFile.txt");
            if (data != null && data != "")
            {
                listBook = JsonConvert.DeserializeObject<List<Book>>(data);
            }

            ShowBook.ItemsSource = listBook;
            this.DataContext = this;
        }

        public void ChangeBook(Object sender, RoutedEventArgs s)
        {
            AddAndChange addList = new AddAndChange();
            addList.Show();
        }

        public void AddBook(Object sender, RoutedEventArgs s)
        {
            AddAndChange addList = new AddAndChange();
            addList.Show();
        }        

        public void DelBook(Object sender, RoutedEventArgs s)
        {
            FileHelper fileHelper = new FileHelper();
            var listBook = new List<Book>();
            var data = fileHelper.FileToString("I:\\c#项目\\BookMannage\\BookMannage\\BookFile.txt");
            listBook = JsonConvert.DeserializeObject<List<Book>>(data);
            var tempId = "";

            Button btn = sender as Button;
            if (btn != null)
            {
                tempId = btn.Tag.ToString();
            }

            var tempBook = listBook.Where(p => p.Id.Equals(tempId)).FirstOrDefault();
            if (tempBook != null) {
                listBook.Remove(tempBook);

                var jsonData = JsonConvert.SerializeObject(listBook);
                var str = fileHelper.SavaProcess(jsonData);
            }
            
        }
    }
}
