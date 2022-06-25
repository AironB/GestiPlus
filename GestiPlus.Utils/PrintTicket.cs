namespace GestiPlus.Utils
{
    internal class PrintTicket
    {
        /*private Graphics graphics;
        private int InitialHeight = 360;
        private PrintDocument PrintDocument;

        public PrintTicket(Order order, Shop shop)
        {
            this.order = order;
            this.shop = shop;
            AdjustHeight();
        }

        private Order order { get; }
        private Shop shop { get; }

        private void AdjustHeight()
        {
            var capacity = 5 * order.ItemTransactions.Capacity;
            InitialHeight += capacity;

            capacity = 5 * order.DealTransactions.Capacity;
            InitialHeight += capacity;
        }

        public void Print(string printername)
        {
            PrintDocument = new PrintDocument();
            PrintDocument.PrinterSettings.PrinterName = printername;

            PrintDocument.PrintPage += FormatPage;
            PrintDocument.Print();
        }

        private void DrawAtStart(string text, int Offset)
        {
            var startX = 10;
            var startY = 5;
            var minifont = new Font("Arial", 5);

            graphics.DrawString(text, minifont,
                new SolidBrush(Color.Black), startX + 5, startY + Offset);
        }

        private void InsertItem(string key, string value, int Offset)
        {
            var minifont = new Font("Arial", 5);
            var startX = 10;
            var startY = 5;

            graphics.DrawString(key, minifont,
                new SolidBrush(Color.Black), startX + 5, startY + Offset);

            graphics.DrawString(value, minifont,
                new SolidBrush(Color.Black), startX + 130, startY + Offset);
        }

        private void InsertHeaderStyleItem(string key, string value, int Offset)
        {
            var startX = 10;
            var startY = 5;
            var itemfont = new Font("Arial", 6, FontStyle.Bold);

            graphics.DrawString(key, itemfont,
                new SolidBrush(Color.Black), startX + 5, startY + Offset);

            graphics.DrawString(value, itemfont,
                new SolidBrush(Color.Black), startX + 130, startY + Offset);
        }

        private void DrawLine(string text, Font font, int Offset, int xOffset)
        {
            var startX = 10;
            var startY = 5;
            graphics.DrawString(text, font,
                new SolidBrush(Color.Black), startX + xOffset, startY + Offset);
        }

        private void DrawSimpleString(string text, Font font, int Offset, int xOffset)
        {
            var startX = 10;
            var startY = 5;
            graphics.DrawString(text, font,
                new SolidBrush(Color.Black), startX + xOffset, startY + Offset);
        }

        private void FormatPage(object sender, PrintPageEventArgs e)
        {
            graphics = e.Graphics;
            var minifont = new Font("Arial", 5);
            var itemfont = new Font("Arial", 6);
            var smallfont = new Font("Arial", 8);
            var mediumfont = new Font("Arial", 10);
            var largefont = new Font("Arial", 12);
            var Offset = 10;
            int smallinc = 10, mediuminc = 12, largeinc = 15;

            //Image image = Resources.logo;
            //e.Graphics.DrawImage(image, startX + 50, startY + Offset, 100, 30);

            //graphics.DrawString("Welcome to HOT AND CRISPY", smallfont,
            //      new SolidBrush(Color.Black), startX + 22, startY + Offset);

            Offset = Offset + largeinc + 10;

            var underLine = "-------------------------------------";
            DrawLine(underLine, largefont, Offset, 0);

            Offset = Offset + mediuminc;
            DrawAtStart("Invoice Number: " + order.Invoice, Offset);

            if (!string.Equals(order.Customer.Address, "N/A"))
            {
                Offset = Offset + mediuminc;
                DrawAtStart("Address: " + order.Customer.Address, Offset);
            }

            if (!string.Equals(order.Customer.Phone, "N/A"))
            {
                Offset = Offset + mediuminc;
                DrawAtStart("Phone # : " + order.Customer.Phone, Offset);
            }

            Offset = Offset + mediuminc;
            DrawAtStart("Date: " + order.Date, Offset);

            Offset = Offset + smallinc;
            underLine = "-------------------------";
            DrawLine(underLine, largefont, Offset, 30);

            Offset = Offset + largeinc;

            InsertHeaderStyleItem("Name. ", "Price. ", Offset);

            Offset = Offset + largeinc;
            foreach (var itran in order.ItemTransactions)
            {
                InsertItem(itran.Item.Name + " x " + itran.Quantity, itran.Total.CValue, Offset);
                Offset = Offset + smallinc;
            }

            foreach (var dtran in order.DealTransactions)
            {
                InsertItem(dtran.Deal.Name, dtran.Total.CValue, Offset);
                Offset = Offset + smallinc;

                foreach (var di in dtran.Deal.DealItems)
                {
                    InsertItem(di.Item.Name + " x " + dtran.Quantity * di.Quantity, "", Offset);
                    Offset = Offset + smallinc;
                }
            }

            underLine = "-------------------------";
            DrawLine(underLine, largefont, Offset, 30);

            Offset = Offset + largeinc;
            InsertItem(" Net. Total: ", order.Total.CValue, Offset);

            if (!order.Cash.Discount.IsZero())
            {
                Offset = Offset + smallinc;
                InsertItem(" Discount: ", order.Cash.Discount.CValue, Offset);
            }

            Offset = Offset + smallinc;
            InsertHeaderStyleItem(" Amount Payable: ", order.GrossTotal.CValue, Offset);

            Offset = Offset + largeinc;
            string address = shop.Address;
            DrawSimpleString("Address: " + address, minifont, Offset, 15);

            Offset = Offset + smallinc;
            var number = "Tel: " + shop.Phone1 + " - OR - " + shop.Phone2;
            DrawSimpleString(number, minifont, Offset, 35);

            Offset = Offset + 7;
            underLine = "-------------------------------------";
            DrawLine(underLine, largefont, Offset, 0);

            Offset = Offset + mediuminc;
            var greetings = "Thanks for visiting us.";
            DrawSimpleString(greetings, mediumfont, Offset, 28);

            Offset = Offset + mediuminc;
            underLine = "-------------------------------------";
            DrawLine(underLine, largefont, Offset, 0);

            Offset += 2 * mediuminc;
            var tip = "TIP: -----------------------------";
            InsertItem(tip, "", Offset);

            Offset = Offset + largeinc;
            var DrawnBy = "Meganos Softwares: 0312-0459491 - OR - 0321-6228321";
            DrawSimpleString(DrawnBy, minifont, Offset, 15);
        }*/
    }
}