using System;
using System.ComponentModel;
using System.Windows.Input;

namespace WpfMvvm
{
    public class CustomerViewModel : INotifyPropertyChanged
    {
        private Customer obj = new Customer();

        public string TxtCustomerName
        {
            get { return obj.CustomerName; }
            set { obj.CustomerName = value; }
        }

        public string TxtAmount
        {
            get { return Convert.ToString(obj.Amount); }
            set { obj.Amount = Convert.ToDouble(value); }
        }

        private ButtonCommand objCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public CustomerViewModel()
        {
            objCommand = new ButtonCommand(this.Calculate); // Point 2
        }

        public ICommand btnClick // Point 3
        {
            get
            {
                return objCommand;
            }
        }


        public string LblAmountColor
        {
            get
            {
                if (obj.Amount > 2000)
                {
                    return "Blue";
                }
                else if (obj.Amount > 1500)
                {
                    return "Red";
                }
                return "Yellow";
            }
        }


        public double Tax
        {
            get
            {
                return obj.Tax;
            }
        }

        public bool IsMarried
        {
            get
            {
                if (obj.Married == "Married")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            set
            {
                if (value)
                {
                    obj.Married = "Married";
                }
                else
                {
                    obj.Married = "Not married";
                }
            }
        }

        public void Calculate()
        {
            obj.CalculateTax();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tax"));
        }

    }
}
