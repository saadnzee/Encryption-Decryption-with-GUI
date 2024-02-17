using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Final_Project_2ndSem
{
    public partial class Form1 : Form
    {
        long n, phi, e1, count_key;          //initialized all the variables globally
        long in_Number, out_Number;
        string str_in = " ";
        string str_out = " ";
        long str_num2;
        long encrypted_number;
        long len = 0, k;
        long[] num_arr = new long[100], cnum_arr = new long[100], dnum_arr = new long[100];
        char[] msg = new char[100], d_msg = new char[100];

        public Form1()
        {
            InitializeComponent();          //function used to initialize all the tools used in the GUI
            n_phi_calc();                   //whenever the program starts it will automatically generate the n, phi etc 
            ed_calculation();               //required
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();             //function used in the "EXIT" button to exit the program
        }

        private void Decrypt_button_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dec_key_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private unsafe void Encrypt_Sel_CheckedChanged(object sender, EventArgs e)
        {                                                   
            Enc_in.Clear();                 //whenever the encrypt button is clicked it will clear out the textboxes used for
                                            //input and output
            Enc_out.Clear();
            if (Encrypt_Sel.Checked == true)    //checks if the encrypt button is selected
            {
                tabControl1.SelectedIndex = 0;  //selects the first index (encrypt tab page)
                tabControl1.Refresh();          

                n_phi_calc();                   //put here to calculate new values of n, phi etc everytime the encrypt
                                                //button is pressed
                ed_calculation();

                
            }
        }

        public long gcd(long a, long b)
        {
            while (a != b)
            {
                if (a > b)
                    a = a - b;
                else
                    b = b - a;
            }
            return a;
        }

        private void enc_button_Click(object sender, EventArgs e)
        {
            if (endec_num.Checked == true)      //checks if the user clicked the number or alphabet button
            {
                in_Number = Convert.ToInt64(Enc_in.Text);   //this function is used to convert the number entered into 
                out_Number = encrypt(in_Number,e1,n);                      //long type
                Enc_out.Text=out_Number.ToString();
            }                                              
            else
            {
                str_in = Enc_in.Text;
                for (int s = 0; s < len; s++)
                {
                    msg[s] = ' ';
                }
                msg = str_in.ToCharArray();          
                len = msg.Length;                              
                Encrypt_text();
            }
          
        }

        private void Enc_in_TextChanged(object sender, EventArgs e)
        {

        }

        public bool is_prime(int num)
        {
            if (num <= 1)
            {
                return false;
            }
            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public long mod_exp(long base_e, long exp, long mod)
        {
            long result = 1;
            while (exp > 0)
            {
                if (exp % 2 == 1)
                {
                    result = (result * base_e) % mod;
                }

                base_e = (base_e * base_e) % mod;     
                exp = exp / 2;
            }

            return result;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Enc_in.Clear();                 //clears the textboxes whenever the number or alphabet button is pressed
            Enc_out.Clear();
        }

        private void endec_str_CheckedChanged(object sender, EventArgs e)
        {
            Enc_in.Clear();
            Enc_out.Clear();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Decrypt_Sel_CheckedChanged(object sender, EventArgs e)
        {
            Dec_in.Clear();                 //clears the decrypt textboxes
            Dec_out.Clear();
            if (Decrypt_Sel.Checked == true)    //checks if the decrypted button is pressed
            {
                tabControl1.SelectedIndex = 1;  //opens the decrypt tab whenever the decrypt button is pressed
                tabControl1.Refresh();
            }
        }

        private void dec_button_Click(object sender, EventArgs e)
        {
            

            if (endec_num.Checked == true)              //check if the number button is selected
            {   in_Number = Convert.ToInt64(Dec_in.Text);   //whenever the decrypt button is pressed in tab box, it starts 
                                                        //decryption process

                out_Number = decrypt(in_Number, count_key, n);                      
                Dec_out.Text = out_Number.ToString();
            }
            else if (endec_str.Checked == true)         //check if the alphabet button is selected
            {
                str_out = " ";
                Decrypt_text();
                for (int k = 0; k < len; k++)
                {
                    str_out = str_out + d_msg[k];
                }
                Dec_out.Text = str_out;
            }
        }

        public long encrypt(long m, long e, long n)
        {     // m = number, e = e, n = n
            return mod_exp(m, e, n);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void Dec_out_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            Decrypt_Sel.Checked = true;
        }

        
        private void tabControl11_SelectedTabChanged(object sender, EventArgs e)
        {
            if  (tabControl1.SelectedIndex == 0)
            {
                Encrypt_Sel.Checked = true;
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                Decrypt_Sel.Checked = true;
            }
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {
            Encrypt_Sel.Checked = true;
        }

        public long decrypt(long c, long count_key, long n)
        {
            return mod_exp(c, count_key, n);
        }

        public unsafe void n_phi_calc()//long n_l, long phi_l)
        {
            //n is the product of random prime numbers generated (value of mod remains same for encryption and decryption)
            //phi is the product of (n-1) random prime numbers
            //e is the encryption key
            //count_key s the decryption key

            //srand(time(NULL));
            Random rnd = new Random((int)DateTime.Now.Ticks);
            //rnd.Next(-1, 1);
            int count = 0;
            long[] arr1 = new long[2];
            while (count < 2)
            {
                //int num = rand() % 10000 + 10000;      // generates random numbers between 10000 to 20000
                int num = rnd.Next(10000, 20000);
                if (is_prime(num))
                {
                    //cout << "Prime number is: " << num << endl;
                    if (count == 0)
                    {
                        prim1.Text = num.ToString();
                    }  
                    
                    arr1[count] = num;
                    if (count == 1)
                    {
                        prim2.Text = num.ToString();
                        n = arr1[0] * arr1[1];
                        phi = (arr1[0] - 1) * (arr1[1] - 1);
                    }
                    count++;
                }
            }
            val_n.Text = n.ToString();
            val_phi.Text = phi.ToString();
            //cout << "n is: " << *n_l << endl;
            //cout << "phi is: " << *phi_l << endl;

        }



        public unsafe void ed_calculation()//long phi_l1, long e, long count_key)
        {
            for (long i = 2; i < phi; i++)
            {
                if (gcd(i, phi) == 1)
                {
                    e1 = i;
                    en_key.Text = e1.ToString();
                    //cout << "e is: " << *e << endl;
                    break;
                }
            }
            for (count_key = 1; ((count_key) * (e1)) % (phi) != 1; (count_key)++) ;
            dec_key.Text= count_key.ToString();
            //cout << "Decryption key is: " << *count_key << endl;
        }

        public void Encrypt_text()
        {

            if (endec_str.Checked == true)
            {
                for (int x = 0; x < len; x++)
                {
                    num_arr[x] = 0;
                }
                for (int x = 0; x < len; x++)
                {
                    num_arr[x] = (long)msg[x];
                }
                for (int x = 0; x < len; x++)
                {
                    cnum_arr[x] = 0;
                }
                long arr2;
                for (k = 0; k < len; k++)
                {
                    arr2 = num_arr[k];
                    cnum_arr[k] = encrypt(arr2, e1, n);
                }
            }
            else if(endec_num.Checked == true)
            {
                str_num2 = in_Number;
            }
            encrypted_number = encrypt(str_num2, e1, n);
            Enc_out.Text = encrypted_number.ToString();     //displays the encrypted number in the textbox
        }

        public void Decrypt_text()
        {
            for(int x = 0; x < len;x++)
            {
                dnum_arr[x] = 0;
            }
            for (k = 0; k < len; k++)
            {
                dnum_arr[k] = decrypt(cnum_arr[k], count_key, n);
                //cout << dnum_arr[k] << endl;
            }
            //cout << "Decrypted text is: ";
            for (k = 0; k < 99;k++)
            {
                d_msg[k] = ' ';
            }
            for (k = 0; k < len; k++)
            {
                d_msg[k] = ((char)dnum_arr[k]);
                //cout << d_msg[k];
            }
        }
    }
}
