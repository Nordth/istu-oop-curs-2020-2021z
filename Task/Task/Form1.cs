using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Task
{
    public partial class Form1 : Form
    {
        List<Product> products;
        List<Dish> dishes;
        List<Dish> dishesInBasket;

        public Form1()
        {
            InitializeComponent();
            LoadProducts();
            LoadDishes();
            LoadDishesToComboBox();
            dishesInBasket = new List<Dish>();
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                LoadProducts();
            }
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                LoadDishesToDataGridView();
            }
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                LoadOrders();                             
            }
        }

        private void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                LoadCurrentOrder();                
            }
        }

        private void LoadProducts()
        {
            try
            {
                button1.Enabled = true;
                label4.Text = "Продукты на складе";
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                dataGridView1.Columns.Add("Продукт", "Продукт");
                dataGridView1.Columns.Add("ЦенаЗаКг", "Цена за кг");
                dataGridView1.Columns.Add("Кол-воКг", "Кол-во (кг)");
                string [] data = File.ReadAllLines(Environment.CurrentDirectory + "\\Продукты.txt");
                products = new List<Product>();

                for (int i = 0; i < data.Count(); i++)
                {
                    string [] temp = data[i].Split(' ');
                    Product product = new Product(temp[0], Convert.ToDouble(temp[1]), Convert.ToDouble(temp[2]));
                    products.Add(product);
                    dataGridView1.Rows.Add();
                    dataGridView1[0, i].Value = temp[0];
                    dataGridView1[1, i].Value = temp[1];
                    dataGridView1[2, i].Value = temp[2];
                }
            }
            catch 
            {
                MessageBox.Show("Ошибка при загрузки продуктов из файла!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDishes()
        {
            try
            {               
                string [] data = File.ReadAllLines(Environment.CurrentDirectory + "\\Блюда.txt");
                dishes = new List<Dish>();
                string ingredientsAndTheirQuantity;

                for (int i = 0; i < data.Count(); i++)
                {
                    ingredientsAndTheirQuantity = "";
                    string[] temp = data[i].Split(' ');
                    List<Product> tempProducts = new List<Product>();
                    Product product = new Product();

                    for (int k = 1; k < temp.Count(); k++)
                    {
                        ingredientsAndTheirQuantity += temp[k] + " ";

                        if (k % 2 != 0)
                        {
                            for (int j = 0; j < products.Count; j++)
                            {
                                if (temp[k] == products[j].Title)
                                {
                                    product.Title = products[j].Title;
                                    product.CostPerKg = products[j].CostPerKg;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            product.QuantityKg = Convert.ToDouble(temp[k]);
                            tempProducts.Add(product);
                            product = new Product();
                        }
                    }

                    Dish dish = new Dish(temp[0], tempProducts);
                    dishes.Add(dish);                   
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при загрузки блюд из файла!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDishesToDataGridView()
        {
            try
            {
                button1.Enabled = true;
                label4.Text = "Меню";
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                dataGridView1.Columns.Add("Блюдо", "Блюдо");
                dataGridView1.Columns.Add("ИнгридиентыИИхКол-во", "Ингридиенты и их кол-во");
                dataGridView1.Columns[1].Width = 250;
                dataGridView1.Columns.Add("Цена", "Цена");
                string [] data = File.ReadAllLines(Environment.CurrentDirectory + "\\Блюда.txt");
                dishes = new List<Dish>();
                string ingredientsAndTheirQuantity;

                for (int i = 0; i < data.Count(); i++)
                {
                    ingredientsAndTheirQuantity = "";
                    string [] temp = data[i].Split(' ');
                    List<Product> tempProducts = new List<Product>();
                    Product product = new Product();

                    for (int k = 1; k < temp.Count(); k++)
                    {
                        ingredientsAndTheirQuantity += temp[k] + " ";

                        if (k % 2 != 0)
                        {
                            for (int j = 0; j < products.Count; j++)
                            {
                                if (temp[k] == products[j].Title)
                                {
                                    product.Title = products[j].Title;
                                    product.CostPerKg = products[j].CostPerKg;                                    
                                    break;
                                }
                            }
                        }
                        else
                        {
                            product.QuantityKg = Convert.ToDouble(temp[k]);
                            tempProducts.Add(product);
                            product = new Product();
                        }
                    }

                    Dish dish = new Dish(temp[0], tempProducts);
                    dishes.Add(dish);
                    dataGridView1.Rows.Add();
                    dataGridView1[0, i].Value = temp[0];
                    dataGridView1[1, i].Value = ingredientsAndTheirQuantity;
                    dataGridView1[2, i].Value = dish.Price;
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при загрузки блюд из файла!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDishesToComboBox()
        {
            try
            {
                string [] data = File.ReadAllLines(Environment.CurrentDirectory + "\\Блюда.txt");
                dishes = new List<Dish>();
                string ingredientsAndTheirQuantity = "";
                List<Product> productsInDishes;

                for (int i = 0; i < data.Count(); i++)
                {
                    string [] temp = data[i].Split(' ');
                    productsInDishes = new List<Product>();
                    Product product = new Product();

                    for (int k = 1; k < temp.Count(); k++)
                    {
                        ingredientsAndTheirQuantity += temp[k] + " ";

                        if (k % 2 != 0)
                        {
                            for (int j = 0; j < products.Count; j++)
                            {
                                if (temp[k] == products[j].Title)
                                {
                                    product.Title = products[j].Title;
                                    product.CostPerKg = products[j].CostPerKg;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            product.QuantityKg = Convert.ToDouble(temp[k]);
                            productsInDishes.Add(product);
                            product = new Product();
                        }
                    }

                    Dish dish = new Dish(temp[0], productsInDishes);
                    dishes.Add(dish);
                    comboBox1.Items.Add(dish.Title);
                    comboBox1.SelectedIndex = 0;
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при загрузки блюд из файла!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOrders()
        {
            try
            {
                if (dateTimePicker2.Value >= dateTimePicker1.Value)
                {
                    button1.Enabled = true;
                    label4.Text = "Заказы";
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();
                    dataGridView1.Columns.Add("Все блюда", "Все блюда");
                    dataGridView1.Columns[0].Width = 300;
                    dataGridView1.Columns.Add("Дата", "Дата");
                    dataGridView1.Columns[1].Width = 150;
                    dataGridView1.Columns.Add("Цена", "Цена, $");
                    string [] data = File.ReadAllLines(Environment.CurrentDirectory + "\\Заказы.txt");
                    int currentRow = 0;

                    for (int i = 0; i < data.Count() - 1; i++)
                    {
                        dataGridView1.Rows.Add();
                    }

                    for (int i = 0; i < data.Count(); i++)
                    {
                        string [] temp = data[i].Split(' ');

                        for (int j = 0; j < temp.Length; j++)
                        {
                            if (Double.TryParse(temp[j], out double temp1))
                            {
                                dataGridView1[2, currentRow].Value = temp[j];
                            }
                            else if (DateTime.TryParse(temp[j], out DateTime temp2))
                            {
                                dataGridView1[1, currentRow].Value += temp[j] + " ";
                            }
                            else 
                            {
                                dataGridView1[0, currentRow].Value += temp[j] + " ";
                            }
                        }

                        if (Convert.ToDateTime(dataGridView1[1, currentRow].Value) >= dateTimePicker1.Value && Convert.ToDateTime(dataGridView1[1, currentRow].Value) <= dateTimePicker2.Value)
                        {
                            currentRow++;
                        }
                        else
                        {
                            dataGridView1[0, currentRow].Value = "";
                            dataGridView1[1, currentRow].Value = "";
                            dataGridView1[2, currentRow].Value = "";
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Вторая дата не может быть меньше первой!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при приведении дат!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        Order order;

        private void LoadCurrentOrder()
        {
            order = new Order(dishesInBasket, DateTime.Now);

            try
            {
                button1.Enabled = false;
                label4.Text = "Текущий заказ";
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                dataGridView1.Columns.Add("Все блюда", "Все блюда");
                dataGridView1.Columns[0].Width = 300;
                dataGridView1.Columns.Add("Дата", "Дата");
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns.Add("Цена", "Цена, $");                

                for (int i = 0; i < dishesInBasket.Count(); i++)
                {
                    dataGridView1[0, 0].Value += dishesInBasket[i].Title + " ";
                    dataGridView1[1, 0].Value = DateTime.Now;
                    dataGridView1[2, 0].Value = order.Price;
                }
            }
            catch
            {

            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            order = new Order(dishesInBasket, DateTime.Now);
            bool flag = false;

            if (radioButton5.Checked == true)
            {
                for (int i = 0; i < dishes.Count; i++)
                {
                    if (dishes[i].Title == comboBox1.SelectedItem.ToString())
                    {
                        dishesInBasket.Add(dishes[i]);
                        List<Dish> dishesInOrder = order.GetListDishes();
                        List<Product> productsInOrder;                        
                        productsInOrder = dishes[i].GetListProducts();

                        for (int j = 0; j < products.Count; j++)
                        {
                            for (int k = 0; k < productsInOrder.Count; k++)
                            {
                                if (products[j].Title == productsInOrder[k].Title && products[j].QuantityKg - productsInOrder[k].QuantityKg <= 0)
                                {
                                    flag = true;
                                    dishesInBasket.Remove(dishes[i]);
                                    MessageBox.Show("На складе нет одного из ингридиентов блюда!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }                               
                            }
                        }

                        if (flag == false)
                        {
                            dishesInBasket.Remove(dishes[i]);
                            dishesInBasket.Add(dishes[i]);
                            MessageBox.Show("Блюдо " + dishes[i].Title + " добавлено в заказ!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    }
                }                
            }
            else 
            {
                for (int i = 0; i < dishesInBasket.Count; i++)
                {
                    if (dishesInBasket[i].Title == comboBox1.SelectedItem.ToString())
                    {
                        flag = true;
                        dishesInBasket.Remove(dishes[i]);
                        MessageBox.Show("Блюдо " + dishes[i].Title + " удалено из заказа!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }

                if (flag == false)
                {
                    MessageBox.Show("Блюдо " + comboBox1.SelectedItem.ToString() + " не найдено в заказе!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            radioButton4.Checked = true;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (order == null || order.Price == 0)
            {
                MessageBox.Show("Блюда в заказе не найдены!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                bool flag = false;

                try
                {
                    File.AppendAllText(Environment.CurrentDirectory + "\\Заказы.txt", order.GetStringDishes() + order.Date + " " + order.Price + '\n');
                }
                catch
                {
                    flag = true;
                }

                if (flag == true)
                {
                    MessageBox.Show("Ошибка при сохранении заказа в файл!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Ваш заказ: " + order.GetStringDishes() + "\nСумма к оплате: " + order.Price + "$\nДата заказа: " + order.Date, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (radioButton4.Checked == true)
                    {
                        dataGridView1.Rows.Clear();
                    }

                    List<Dish> dishesInOrder = order.GetListDishes();
                    List<Product> productsInOrder;

                    for (int i = 0; i < dishes.Count; i++)
                    {
                        for (int h = 0; h < dishesInOrder.Count; h++)
                        {
                            if (dishesInOrder[h].Title == dishes[i].Title)
                            {
                                productsInOrder = dishes[i].GetListProducts();

                                for (int j = 0; j < products.Count; j++)
                                {
                                    for (int k = 0; k < productsInOrder.Count; k++)
                                    {
                                        if (products[j].Title == productsInOrder[k].Title)
                                        {
                                            products[j].QuantityKg -= productsInOrder[k].QuantityKg;
                                        }
                                    }
                                }
                            }
                        }                        
                    }

                    SaveDataToFileFromList("Продукты");
                    order = null;
                    dishesInBasket.Clear();
                }
            }
        }     

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dishes.Count; i++)
            {
                if (dishes[i].Title == comboBox1.SelectedItem.ToString())
                {
                    label3.Text = dishes[i].Price.ToString();
                    break;
                }
            }
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                SaveDataToFileFromDataGridView("Продукты");
            }
            else if (radioButton2.Checked == true)
            {
                SaveDataToFileFromDataGridView("Блюда");
            }
            else if (radioButton3.Checked == true)
            {
                SaveDataToFileFromDataGridView("Заказы");
            }
        }

        private void SaveDataToFileFromDataGridView(string fileName)
        {
            bool flag = false;
            File.WriteAllText(Environment.CurrentDirectory + "\\" + fileName +".txt", "");

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1[0, i].Value != null && dataGridView1[0, i].Value.ToString() != "" && dataGridView1[1, i].Value.ToString() != "" && dataGridView1[2, i].Value.ToString() != "")
                {
                    try
                    {
                        File.AppendAllText(Environment.CurrentDirectory + "\\" + fileName + ".txt", dataGridView1[0, i].Value + " " + dataGridView1[1, i].Value + " " + dataGridView1[2, i].Value + '\n');
                    }
                    catch
                    {
                        flag = true;
                    }
                }
            }

            if (flag == true)
            {
                MessageBox.Show("Ошибка при сохранении данных в файл!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Данные успешно сохранены в файл", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SaveDataToFileFromList(string fileName)
        {
            bool flag = false;
            File.WriteAllText(Environment.CurrentDirectory + "\\" + fileName + ".txt", "");

            for (int i = 0; i < products.Count; i++)
            {
                try
                {
                    File.AppendAllText(Environment.CurrentDirectory + "\\" + fileName + ".txt", products[i].Title + " " + products[i].CostPerKg + " " + products[i].QuantityKg + '\n');
                }
                catch
                {
                    flag = true;
                }
            }

            if (flag == true)
            {
                MessageBox.Show("Ошибка при сохранении данных в файл!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Кол-во продуктов на складе уменьшено после оформления заказа. Данные успешно сохранены в файл.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
