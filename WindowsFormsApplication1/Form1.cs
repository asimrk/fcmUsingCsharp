﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // checking input values
        public void Check() {
            if (checkNotification.Checked == true || checkData.Checked == true)
            {
                send.Enabled = true;
            }
            else
            {
                send.Enabled = false;
            }
        }

        


        RootObject dataObject = new RootObject();
        //Data data = new Data();
        //Notification notification = new Notification();
        //RootObject root = new RootObject();
        
        
        

        // Registration Tokens
         static string[] tokenIDs = new string[] 
            {
            
            // Android Devices
            "cOsw768wUqM:APA91bHnhyqZma4MImb82ntdmCi693WuhgnoSVZpMGXAFebU3ft25vj4KdSQ6k3cmX9KFvxIEOsjudjUdiqKeGTTn-JSEWwIm_QzuNrcw81aI9d9EOctscB7f5DSIcUrvPjLsRPo8nOs",
            "dS_cw7JzNGo:APA91bGr6Z6gnW_YywMp1Qu4afVQ0l2VY3Zh9XpFR6oiPSyUkBOGWFkgyOO_PO8FF10TvUOaSWKosAV-9vsTPXHYFEeOkLEJh79AUDeo2ShrLele9ocJGOWqwjQ5XYzpeOZ4CrsmzVax",

            // iOS Devices
            "el-rHjHPuaM:APA91bGvOHMgQxMgzoVmV9vnKshqnXNw8J6yDgOht2l1WNMjiZPqz3N5SsqEUKtSi_ZXHzNTXjwrN5iZBxH4_-cEvkO8mBzLRkPs3YNhMVhpJt4LjrGGn6Va_cTY5JNROVyFUHGxnpH4",
            "dTIYt93aJ1E:APA91bHToM7BUOWW_8qDpojMAysJvkJQpbN1IS1b8PuPhOOutBJ7FxFfO2d_zCg5N5zzgWSVrVsVu9PMv796MgGL8E-s0JRa__JZwNJNC7eH_RMhisVChMwTkZKtPbGDh7mjCbAbdeTb",
            };
 
        
        // Sending this to FCM
        //object dataObject = new
        //{
        //    // Targets
        //    // to = "/topics/news",  // Optional, This parameter specifies the recipient of a message.
        //    registration_ids = tokenIDs,

        //    // Options
        //    collapse_key = "JOBs",
        //    priority = "high",
        //    content_available = true,
        //    delay_while_idle = false,
        //    time_to_live = 2419200,  // min is 0 sec and max is 4 weeks is 2,419,200 sec.

        //    // Paylod Data messages, which are handled by the client app.
        //    data = new
        //    {
        //        alert = "Data Message",
        //        job = "Incomming Job",
        //        time = System.DateTime.Now.ToString()
        //    },

        //    //Notification messages, sometimes thought of as "display messages."
        //     notification = new
        //    {
                
        //        title = , //"Buzy Beez",
        //        body = "Umer",
        //        sound = "default",
        //        badge = 1,
        //        icon = "myicon" // workin in android
        //    }

        //};

     
        //Product product = new Product();
        //product.Name = "Apple";
        //product.Expiry = new DateTime(2008, 12, 28);
        //product.Sizes = new string[] { "Small" };

         
        //// {
        ////   "Name": "Apple",
        ////   "Expiry": "2008-12-28T00:00:00",
        ////   "Sizes": [
        ////     "Small"
        ////   ]
        //// }

      

        private void comboUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the currently selected item in the ListBox.
            string curItem = comboUser.SelectedItem.ToString();
              
        }

        private void comboPlatform_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkNotification_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxNotification.Enabled = (checkNotification.Checked) ? true : false; 
        }

        private void checkData_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxMessage.Enabled = (checkData.Checked) ? true : false;
        }

        private void title_TextChanged(object sender, EventArgs e)
        {

        }

        private void title_Enter(object sender, EventArgs e)
        {

        }


        private void body_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboSound_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBadge_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {



            // initlizating data

            if(checkNotification.Checked){
                dataObject.AssigningNotificationValues(title, body, comboSound, comboBadge);
            } else if(checkData.Checked ){
                dataObject.AssigningDataValues(message);
            }

            //dataObject.AssigningNotificationValues(title, body, comboSound, comboBadge);
            //dataObject.AssigningDataValues(message);
            dataObject.FcmPropertieValues(collapsKey,comboPriority,timeToLive,checkAvailablity,checkDelay,tokenIDs);
            
            // Pushing into FCM
            AndroidFCMPushNotification FCM = new AndroidFCMPushNotification();
            string responseFromServer = FCM.SendNotification(dataObject);
            MessageBox.Show("Response Status: " + responseFromServer);


        }

        public void Submit() {
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkData_MouseClick(object sender, MouseEventArgs e)
        {
            Check(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // checking check boxes.
            Check();

            //dataObject.AssigningNotificationValues(title,body,comboSound,comboBadge);
            //dataObject.FcmPropertieValues(collapsKey, comboPriority, timeToLive, checkAvailablity, checkDelay, tokenIDs);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

       
    }

    

}
