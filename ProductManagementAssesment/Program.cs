using System.Data.SqlClient;

namespace ProductManagementAssesment
{
    class Product
    {
        SqlConnection conn = new SqlConnection("Server=IN-9SB79S3;database=productdb;Integrated Security=true");
        
        public void addproduct()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand($"insert into product values(@productname,@productdescription,@quantity,@price)",conn);
            Console.WriteLine("enter product name");
            string productname=Console.ReadLine();
            Console.WriteLine("enter product description");
            string productdescription=Console.ReadLine();
            Console.WriteLine("enter product quantity");
            int quantity=Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("enter price");
            int price=Convert.ToInt32(Console.ReadLine());
            cmd.Parameters.AddWithValue("@productname", productname);
            cmd.Parameters.AddWithValue("@productdescription", productdescription);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.ExecuteNonQuery();
            Console.WriteLine("product added successfully");
            conn.Close();

        }
        public void viewproduct()
        {
            conn.Open();
            
                Console.WriteLine("enter the id you want to view");
                int id = Convert.ToInt16(Console.ReadLine());
           
            SqlCommand cmd = new SqlCommand($"select * from product where id=@id ", conn);
            cmd.Parameters.AddWithValue ("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                Console.WriteLine("there is no product with such id");
            }
            else
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write($"{reader[i]} |");
                    }
                    Console.WriteLine();
                }
            }
            conn.Close();

        }
        public void viewproduts() 
        {
            conn.Open ();
            SqlCommand cmd = new SqlCommand("select * from product", conn);
            SqlDataReader reader=cmd.ExecuteReader();
            if (reader!=null)
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write($"{reader[i]} |");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("there are no products to display");
            }
            conn.Close();

        } 
        public void updateproduct()
        {
            conn.Open();
            
            Console.WriteLine("enter the id you want to update");
            
            int id= Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("enter the new product name");
            string name = Console.ReadLine();
            Console.WriteLine("enter the new product description");
            string description= Console.ReadLine();
            Console.WriteLine("enter the new quantity");
            int quantity= Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("enter new price");
            int price= Convert.ToInt32(Console.ReadLine());
            SqlCommand cmd = new SqlCommand("update product set productname=@name,productdescription=@description,quantity=@quantity,price=@price where id=@id", conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@id",id);
            int result1=cmd.ExecuteNonQuery();
            if (result1>0)
            {
                Console.WriteLine("product updated successfully");
            }
            else
            {
                Console.WriteLine("product not found");
            }
            conn.Close();

        }
        public void deleteproduct()
        {
            conn.Open();
           
            Console.WriteLine("enter the id you want to delete");
            int id = Convert.ToInt16(Console.ReadLine());
            SqlCommand cmd = new SqlCommand($"delete from product where id=@id ", conn);
            cmd.Parameters.AddWithValue("@id", id);
            int result2=cmd.ExecuteNonQuery ();
            if (result2 > 0)
            {
                Console.WriteLine("product deleted successfully");
            }
            else
            {
                Console.WriteLine("there is no product with such id");
            }
            conn.Close ();
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string ans = " ";
            Product obj = new Product();
            do
            {
                Console.WriteLine("welcome to product management app");
                Console.WriteLine("1.add product");
                Console.WriteLine("2.view product");
                Console.WriteLine("3.view all products");
                Console.WriteLine("4.update product");
                Console.WriteLine("5.delete product");
                int choice = 0;
                try
                {
                    Console.WriteLine("enter your choice");
                     choice=Convert.ToInt32(Console.ReadLine());
                }
                catch(FormatException)
                {
                    Console.WriteLine("enter only integer values");
                }
                switch (choice)
                {
                    case 1:
                        {
                            obj.addproduct();
                            break;
                        }
                    case 2:
                        {
                            obj.viewproduct();
                            break;
                        }
                    case 3:
                        {
                            obj.viewproduts();

                            break;
                        }
                    case 4:
                        {
                            obj.updateproduct();
                            break;
                        }
                    case 5:
                        {
                            obj.deleteproduct();
                            break;
                        }

                }
                Console.WriteLine("do you want to continue[y/n]");
                ans = Console.ReadLine();
            } while (ans.ToLower() == "y");
        }


    }
}
