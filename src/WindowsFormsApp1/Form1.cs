using Autocomplete.DAL.DataServices;
using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private delegate void InitializeAsyncDelegate(bool isMock);
        private delegate int AddAsyncDelegate(int a, int b);
        private IAsyncResult async;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InitializeAsyncDelegate initialize = DataServices.Initialize;
            async = initialize.BeginInvoke(true, InitializeAsync, null);
            AddAsyncDelegate add = Add;
            add.BeginInvoke(2, 3, Initialize1Async, null);
        }

        private void InitializeAsync(IAsyncResult iAsyncResult)
        {
            AsyncResult asyncResult = iAsyncResult as AsyncResult;
            InitializeAsyncDelegate caller = asyncResult.AsyncDelegate as InitializeAsyncDelegate;
            caller.EndInvoke(iAsyncResult);

            Invoke(new Action(() =>
            {
                label1.Text = "asdasd";
            }));
        }

        private void Initialize1Async(IAsyncResult iAsyncResult)
        {
            AsyncResult asyncResult = iAsyncResult as AsyncResult;
            AddAsyncDelegate caller = asyncResult.AsyncDelegate as AddAsyncDelegate;
            var result = caller.EndInvoke(iAsyncResult);

            Invoke(new Action(() =>
            {
                label1.Text = result.ToString();
            }));
        }

        private int Add(int a, int b)
        {
            Thread.Sleep(3000);
            return a + b;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           

        }
    }
}
