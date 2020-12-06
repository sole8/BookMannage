using BookMannage.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BookMannage
{
    /// <summary>
    /// AddAndChange.xaml 的交互逻辑
    /// </summary>
    public partial class AddAndChange : Window
    {
        public AddAndChange()
        {
            InitializeComponent();
        }

        public void CloseAdd(Object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public void SaveBook(Object sender, RoutedEventArgs e)
        {
            FileHelper fileHelper = new FileHelper();
            var listBook = new List<Book>();
            var data = fileHelper.FileToString("I:\\c#项目\\BookMannage\\BookMannage\\BookFile.txt");
            if (data != null&&data != "") {
                listBook = JsonConvert.DeserializeObject<List<Book>>(data);
            }
           

            var book = new Book();
            book.Id = Id.Text;
            book.InDay = DateTime.Now;
            book.Kind = Kind.Text;
            book.BookName = bookName.Text;

            listBook.Add(book);

            var jsonData = JsonConvert.SerializeObject(listBook);
            var str = fileHelper.SavaProcess(jsonData);
            if (str != "") {
                this.Close();
            }
        }
    }
}
