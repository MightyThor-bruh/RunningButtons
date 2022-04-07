#region
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace RunningButtons
{
    //помощник для манипулирования объектами из разных потоков
    public delegate void HelperToCall(Button btn);

    public partial class MainForm : Form
    {
        #region Fields
        Thread t1; //поток для движения первой кнопки
        Thread t2; //поток для движения творой кнопки
        Thread t3; //поток для движения третьей кнопки

        HelperToCall helper;//делегат для вызова методом Invoke()

        static Random r; //отвечает за беспредел

        ButtonCompare[] button;//массив диких кнопок

        SoundPlayer running, background;//мелодия движущегося автомобиля и смешная мелодия
        #endregion

        #region Конструктор
        public MainForm()
        {
            running = new SoundPlayer(Properties.Resources._94_Truck_snd_run03);
            background = new SoundPlayer(Properties.Resources.Final__iz_filma_Usatyi_njan_);
            background.Play();

            Thread.Sleep(500);
            InitializeComponent();

            //массив кнопок
            button = new ButtonCompare[] { first_btn, second_btn, third_btn};

            //указание конкоретного метода для делегата
            helper = new HelperToCall(Motion);

            //рождение песпредела
            r = new Random();  
        }
        #endregion

        #region start_btn_Click
        /// <summary>
        /// Метод вызывается при нажатии кнопки Start.
        /// Создает и запускает потоки если они не были созданы.
        /// Возобновляет потоки, если они были приостановлены
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void start_btn_Click(object sender, EventArgs e)
        {
            running.Play();

            Switcher(false, true, true);

            if (t1 != null)//если потоки существуют - кнопки двигаются, но приостановлены на время
            {
                t1.Resume();
                t2.Resume();
                t3.Resume();
                return;
            }

            t1 = new Thread(Movement1);
            t2 = new Thread(Movement2);
            t3 = new Thread(Movement3);

            t1.IsBackground = t2.IsBackground = t3.IsBackground = true;

            t1.Start();
            t2.Start();
            t3.Start();
        }
        #endregion

        #region pause_btn_Click
        /// <summary>
        /// Приостанавливает потоки в случае нажатия кнопки Pause
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pause_btn_Click(object sender, EventArgs e)
        {
            background.Play();

            Switcher(true, false, true);

            if (t1 != null)
            {
                t1.Suspend();
                t2.Suspend();
                t3.Suspend();
            }
        }
        #endregion

        #region stop_btn_Click
        /// <summary>
        /// Приостанавливает потоки и сбрасывает достижения кнопок в случае нажатия кнопки Stop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stop_btn_Click(object sender, EventArgs e)
        {
            background.Play();

            pause_btn_Click(sender, e);

            Reset();

            Switcher(true, false, false);
        }
        #endregion
        
        #region Motion
        /// <summary>
        /// Двигает конкретную кнопку, получаемую в качестве параметра
        /// </summary>
        /// <param name="button"></param>
        void Motion(Button button)
        {
            button.Location = new Point(button.Location.X + r.Next(2), button.Location.Y);
            Lider();

            Finish(button);
        }
        #endregion       

        #region Movement1
        /// <summary>
        /// Отвечает за движение первой кнопки
        /// </summary>
        void Movement1()
        {
            while (true)
            {
                Thread.Sleep(r.Next(5, 40));
                Invoke(helper, first_btn);
            }
        }
        #endregion

        #region Movement2
        /// <summary>
        /// Отвечает за движение второй кнопки
        /// </summary>
        void Movement2()
        {
            while (true)
            {
                Thread.Sleep(r.Next(5, 40));
                Invoke(helper, second_btn);
            }
        }
        #endregion

        #region Movement3
        /// <summary>
        /// Отвечает за движение третьей кнопки
        /// </summary>
        void Movement3()
        {
            while (true)
            {
                Thread.Sleep(r.Next(5, 40));
                Invoke(helper, third_btn);
            }
        }
        #endregion

        #region Finish
        /// <summary>
        /// Определяет победителя и останавливает движение кнопок в случае
        /// победы одной из них
        /// </summary>
        /// <param name="button"></param>
        private void Finish(Button button)
        {
            if (button.Location.X > (pictureBox1.Location.X - button.Width))
            {
                pause_btn_Click(new object(), new EventArgs());
                start_btn.Enabled = false;

                background.Play();
                MessageBox.Show("Выиграла кнопка " + button.Text);
            }
        }
        #endregion
     
        #region Lider
        /// <summary>
        /// Одевает желтую майку лидера на лидирующую в данный момент кнопку
        /// </summary>
        private void Lider()
        {
            Array.Sort(button);
            button[0].BackColor = Color.Yellow;

            for (int i = 1; i < button.Length; i++)
                button[i].BackColor = SystemColors.Control;
        }
        #endregion

        #region Reset
        /// <summary>
        /// Сбрасывает кнопки в начальное состояние
        /// </summary>
        private void Reset()
        {
            first_btn.Location = new Point(13, first_btn.Location.Y);
            second_btn.Location = new Point(13, second_btn.Location.Y);
            third_btn.Location = new Point(13, third_btn.Location.Y);

            foreach (ButtonCompare btn in button)
                btn.BackColor = SystemColors.Control;
        }
        #endregion

        #region MainForm_FormClosing
        /// <summary>
        /// Нормально завершает работу приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            stop_btn_Click(sender, new EventArgs());
        }
        #endregion

        #region Switcher
        /// <summary>
        /// Управляет доступностью кнопок
        /// </summary>
        /// <param name="flagStart"></param>
        /// <param name="flagPause"></param>
        /// <param name="flagStop"></param>
        void Switcher(bool flagStart, bool flagPause, bool flagStop)
        {
            start_btn.Enabled = flagStart;
            pause_btn.Enabled = flagPause;
            stop_btn.Enabled = flagStop;
        }
        #endregion
    }
}
#endregion