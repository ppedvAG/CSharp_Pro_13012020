using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace HalloAsyncAwait
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


        private void StartOhneThread(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                pb1.Value = i;
                Thread.Sleep(300);
            }
        }

        private void StartTask(object sender, RoutedEventArgs e)
        {
            var b = (Button)sender;
            this.Cursor = Cursors.Wait;
            b.IsEnabled = false;
            Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    pb1.Dispatcher.Invoke(() => pb1.Value = i);
                    Thread.Sleep(10);
                }
                b.Dispatcher.Invoke(() => b.IsEnabled = !false);
                this.Dispatcher.Invoke(() => this.Cursor = Cursors.Arrow);

            });
        }

        private void StartTaskTS(object sender, RoutedEventArgs e)
        {
            var b = (Button)sender;
            b.IsEnabled = false;
            cts = new CancellationTokenSource();
            var ts = TaskScheduler.FromCurrentSynchronizationContext();
            Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(100);
                    Task.Factory.StartNew(() => pb1.Value = i, cts.Token, TaskCreationOptions.None, ts);
                    if (cts.IsCancellationRequested)
                        break;
                }

                Task.Factory.StartNew(() => { b.IsEnabled = !!!!!!!!!!!!!!!false; }, CancellationToken.None, TaskCreationOptions.None, ts);
            });

        }

        CancellationTokenSource cts = null;

        private void Abort(object sender, RoutedEventArgs e)
        {
            cts?.Cancel();
        }

        private async void StartAsync(object sender, RoutedEventArgs e)
        {
            var b = (Button)sender;
            b.IsEnabled = false;

            for (int i = 0; i < 100; i++)
            {
                pb1.Value = i;
                await Task.Delay(100);
            }
            b.IsEnabled = !false;

        }

        private async void DbAsync(object sender, RoutedEventArgs e)
        {
            string conString = "Server=WINDOWS10-AR2;Database=Northwind;Trusted_Connection=true;";
            var b = (Button)sender;
            b.IsEnabled = false;
            pb1.IsIndeterminate = true;
            try
            {

                using (var con = new SqlConnection(conString))
                {
                    await con.OpenAsync();
                    using (var cmd = con.CreateCommand())
                    {
                        cmd.CommandText = "SELECT COUNT(*) FROM Employees;WAITFOR DELAY '00:00:05'";
                        var count = (int)await cmd.ExecuteScalarAsync();
                        MessageBox.Show($"{count} Employees");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Schade:{ex.Message} ");
            }

            b.IsEnabled = !false;
            pb1.IsIndeterminate = !true;


        }

        private async void StartAlt(object sender, RoutedEventArgs e)
        {
            var cts = new CancellationTokenSource();
            cts.Cancel();

            try
            {
                MessageBox.Show($"Alte Funktion: {await CalcAlteFunktionAsync(15, cts.Token)}");
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Abgebrochen");
            }
        }

        public Task<long> CalcAlteFunktionAsync(int zahl, CancellationToken cancel)
        {
            cancel.ThrowIfCancellationRequested();
            return Task.Run(() => CalcAlteFunktion(zahl));
        }

        public long CalcAlteFunktion(int zahl)
        {
            Thread.Sleep(3000);
            return 456789;
        }

        private  void MultiTasks(object sender, RoutedEventArgs e)
        {

            var t1 = new Task<int>(() => 566);

            var t2 = new Task<int>(() => { return -1217; });

            Task.WhenAll(t1, t2).ContinueWith(tr => MessageBox.Show(tr.Result.Sum().ToString()));

            t1.Start();
            t2.Start();
        }
    }
}
