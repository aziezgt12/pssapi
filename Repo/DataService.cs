using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using krodect.api.Dtos.OTP;
using krodect.api.Repo.Interfaces.Master;
using krodect.api.Utility;
using System.Linq;
using krodect.api.Dtos.Master;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace krodect.api.Repo
{
    public class DataService : BackgroundService
    {
        private readonly ILogger<DataService> _logger;
        private readonly IDataRepo _dataRepo;
        private readonly IUserRepo _userRepo;

        public DataService(ILogger<DataService> logger, IDataRepo dataRepo, IUserRepo userRepo)
        {
            _logger = logger;
            _dataRepo = dataRepo;
            _userRepo = userRepo;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
             while (!stoppingToken.IsCancellationRequested)
            {

                try
                {



                    string emailAddress = "rsuppsg@gmail.com";
                    string password = "nhty juhr stdy siiy";

                    // Ganti dengan alamat email penerima
                    string toAddress = "eva.nurafni@rsup.co.id";

                    // Membuat pesan email
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("rsup psg", emailAddress));
                    message.To.Add(new MailboxAddress("Recipient Name", toAddress));
                    message.Subject = "test";
                    message.Body = new TextPart("plain")
                    {
                        Text = "Test body"
                    };

                    // Mengonfigurasi koneksi SMTP
                    using (var client = new SmtpClient())
                    {
                        // Ganti dengan informasi server dan port yang sesuai
                        client.Connect("smtp.gmail.com", 587, false);

                        // Ganti dengan informasi akun Gmail Anda
                        client.Authenticate(emailAddress, password);

                        // Kirim email
                        client.Send(message);

                        // Tutup koneksi
                        client.Disconnect(true);
                    }

                    Console.WriteLine("Email berhasil dikirim!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


                //var apiClient = new ApiClient("http://localhost:5298/apiwhatsapp/info/");

                //var param = new UserFilterDTO
                //{
                //    send_reminder = true,
                //    is_active = true,
                //    wa_null = false
                //};
                //var users = await _userRepo.GetAllByParam(param); // Tunggu hingga task selesai

                ////buatkan export file ke excel 



                //var requestData = new SendDocumentDTO
                //{
                //    caption = "Reminder Alert Maintenance 28/09/2023",
                //    media_pic_public = "http://192.168.12.1/tpm/dokumen/Data_20230718_114117.xlsx",
                //    no_hp_items = users.Select(user => new WaNumber { no_hp = user.wa_number }).ToList()
                //};


                //string obj = JsonConvert.SerializeObject(requestData);

                //var response = await apiClient.Post("forward_message", obj);

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
        //protected async Task SendTelegram()
    }

}
