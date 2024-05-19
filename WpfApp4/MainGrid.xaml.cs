using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для MainGrid.xaml
    /// </summary>
    public partial class MainGrid : Page
    {
        trademagazinEntities db = new trademagazinEntities();
        private List<User> users = new List<User>();
        public MainGrid()
        {
            InitializeComponent();
            UserGrid.ItemsSource = db.User.ToList();

            List<Role> roles = new List<Role>();
            roles.Add(new Role() { Name_role = "Все роли" });
            roles.AddRange(db.Role.OrderBy(t=> t.Name_role).ToList());
        }

        public void GetUser()
        {
            UserGrid.ItemsSource = db.User.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            string id = ID_User.Text;
            string name_user= Name_User.Text;
            string sname_user = SName_User.Text;
            string phone = Phone_User.Text;
            string id_role = ID_Role.Text;
            string login_user = Login_User.Text;
            string pass_user = Pass_User.Text;
            User users = new User(id, name_user, sname_user, phone, id_role, login_user, pass_user);
            db.User.Add(users);
            db.SaveChanges();
            GetUser();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var  selected = UserGrid.SelectedItem as User;
            if(selected != null)
            {
                db.User.Remove(selected);
                db.SaveChanges();
                GetUser();
            }
        }

        private void SercheHeader_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
    }
}
