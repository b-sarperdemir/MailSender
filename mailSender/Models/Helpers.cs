using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mailSender.Dal;
using System.Net.Mail;

namespace mailSender.Models
{
    public class Helpers : IDisposable
    {
        Dal.multiMailSendindingEntities db = new multiMailSendindingEntities();
        [HttpGet]
        public List<mailList> getMailList()
        {
            List<mailList> data = db.mailLists.ToList();
            return data;
        }

        public bool deleteMailList(int id)
        {
            bool sonuc = false;
            try
            {
                mailList data = db.mailLists.Find(id);
                db.mailLists.Remove(data);
                db.SaveChanges();
                sonuc = true;
            }
            catch
            {
                sonuc = false;
            }
            return sonuc;
        }

        public bool addMailList(mailList data)
        {
            bool sonuc = false;
            db.mailLists.Add(data);
            int deger = db.SaveChanges();
            sonuc = deger == 0 ? false : true;
            return sonuc;
        }

        public bool emailGonder(string subject, int[] idlist, string body)
        {
            bool sonuc = false;
            try
            {
                List<string> adresler = db.mailLists.Where(r => idlist.Contains(r.id)).Select(t => t.email).ToList();
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("sarper.dmr@gmail.com", "Test Toplu Mail Gönderim");
                foreach (var item in adresler)
                {
                    mail.To.Add(new MailAddress(item, item));
                }
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.Credentials = new System.Net.NetworkCredential("sarper.dmr@gmail.com", "26541453istist");
                client.EnableSsl = true;


                client.Send(mail);
                sonuc = true;
            }
            catch 
            {
                sonuc = false;
            }
            return sonuc;
        }


        public void Dispose()
        {
            db.Dispose();
            GC.SuppressFinalize(this);
        }
    }


}