using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MultipartFormDataSample.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //var imageSet = new ImageSet()
            //{
            //    Name = "Model",
            //    Images = Directory
            //        .EnumerateFiles("../../../../../SampleImages")
            //        .Where(file => new[] { ".jpg", ".png" }.Contains(Path.GetExtension(file)))
            //        .Select(file => new Image
            //        {
            //            FileName = Path.GetFileName(file),
            //            MimeType = MimeMapping.GetMimeMapping(file),
            //            ImageData = File.ReadAllBytes(file)
            //        })
            //        .ToList()
            //};

            //var eventModel = new FileModel<CreateActivityModel>()
            //{
            //    Image = Directory
            //          .EnumerateFiles("../../../../../SampleImages")
            //          .Where(file => new[] { ".jpg", ".png" }.Contains(Path.GetExtension(file)))
            //          .Select(file => new ImageModel(Path.GetFileName(file), MimeMapping.GetMimeMapping(file), File.ReadAllBytes(file)))
            //          .First(),
            //    Entity = new CreateActivityModel()
            //    {
            //        ActivityName = "event1",

            //        CreatorId = Guid.NewGuid(),
            //        Location = new LocationModel()
            //        {
            //            Latitude = 111,
            //            Longitude = 102,
            //            DisplayName = "chengdu",
            //        },
            //        Weather = Weather.Sun,
            //        Participants = new List<Guid>() { Guid.NewGuid() }
            //    }

            //};
            //SendImageSet(imageSet);

            var createActivityModel = new CreateActivityModel()
            {
                ActivityName = "event1",
                CreatorId = new Guid("4E2422F7-627C-4C8A-96B7-50220C9B1850"),
                Location = new LocationModel()
                {
                    Latitude = 111,
                    Longitude = 102,
                    DisplayName = "chengdu",
                },
                Weather = Weather.Sun,
                Participants = new List<Guid>() { Guid.NewGuid() },
                ActivityCover = Directory
                          .EnumerateFiles("../../../../../SampleImages")
                          .Where(file => new[] { ".jpg", ".png" }.Contains(Path.GetExtension(file)))
                          .Select(file => new FileModel() 
                          {
                              FileName = Path.GetFileName(file),
                              FileType= FileType.Image,
                              FileBytes= File.ReadAllBytes(file)
                          })
                          .First()
            };
            SendEvent(createActivityModel);
        }

        private static void SendImageSet(ImageSet imageSet)
        {
            var multipartContent = new MultipartFormDataContent();

            var imageSetJson = JsonConvert.SerializeObject(imageSet,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

            multipartContent.Add(new StringContent(imageSetJson, Encoding.UTF8, "application/json"), "imageset");

            int counter = 0;
            foreach (var image in imageSet.Images)
            {
                var imageContent = new ByteArrayContent(image.ImageData);
                imageContent.Headers.ContentType = new MediaTypeHeaderValue(image.MimeType);
                multipartContent.Add(imageContent, "image" + counter++, image.FileName);
            }

            var response = new HttpClient()
                .PostAsync("http://localhost:53908/api/send", multipartContent)
                .Result;

            var responseContent = response.Content.ReadAsStringAsync().Result;
            Trace.Write(responseContent);
        }

        //private static void SendEvent(CreateActivityModel eventModel)
        //{
        //    var multipartContent = new MultipartFormDataContent();

        //    var eventJson = JsonConvert.SerializeObject(eventModel);

        //    multipartContent.Add(new StringContent(eventJson, Encoding.UTF8, "application/json"), "event");

        //    int counter = 0;

        //    //foreach (var image in imageSet.Images)
        //    //{
        //    //    var imageContent = new ByteArrayContent(image.ImageData);
        //    //    imageContent.Headers.ContentType = new MediaTypeHeaderValue(image.MimeType);
        //    //    multipartContent.Add(imageContent, "image" + counter++, image.FileName);
        //    //}

        //    var imageContent = new ByteArrayContent(eventModel.Image.Buffer);
        //    imageContent.Headers.ContentType = new MediaTypeHeaderValue(eventModel.Image.MediaType);
        //    multipartContent.Add(imageContent, "cover", eventModel.Image.FileName);

        //    var response = new HttpClient()
        //        .PostAsync("http://localhost:53908/api/create", multipartContent)
        //        .Result;

        //    var responseContent = response.Content.ReadAsStringAsync().Result;
        //    Trace.Write(responseContent);
        //}


        private static void SendEvent(CreateActivityModel eventModel)
        {

            var request = JsonConvert.SerializeObject(eventModel);
            HttpContent httpContent = new StringContent(request);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer XUQZFuPn1Obq59Fs7Q8uMuldQDox7JicsBC62LyzYFGL_dh1qF4Y9U_yn1JGSDD7W_iewJGGzf4vxyCWxRiIIl8T_amRlFrU8Aqa86TRQ1HyOoP7P7HlssiXRhVtGYo7-FFSqaeWGyWcd5wVfEBZrGDsGcd6mgi6yk221GxAqhMBTjwIsYu6j1Q3VOzgE0yVUBTOjGhV2_qQNnf4NS3H3CcvNPGXtvlBBeoq8xbV-ElcyAm7qPie5n7WDzMcWp8lWwCCKh7nW74FHdcyLTVm304SmRcd-fiw-8CcXwjCFylhNYwdJhBq-TkDzz9zxkEU9dscqjLRCKvgSmEAypb4p_fZRCF7jOQbgtrgri01I30");
            //var response = httpClient
            //    .PostAsync("http://localhost:51742/api/unstartedevents/5F5D8313-BE4F-4DC5-A9EB-6F9AEC406F2E/start", httpContent)
            //    .Result;

            var response = httpClient
             .PostAsync("http://localhost:51742/api/events", httpContent)
             .Result;

            var responseContent = response.Content.ReadAsStringAsync().Result;
            Console.ReadKey();
           // var multipartContent = new MultipartFormDataContent();

           // httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36");
           // var eventJson = JsonConvert.SerializeObject(eventModel);

           // multipartContent.Add(new StringContent(eventJson, Encoding.UTF8, "application/json"), "event");

           // int counter = 0;

           // //foreach (var image in imageSet.Images)
           // //{
           // //    var imageContent = new ByteArrayContent(image.ImageData);
           // //    imageContent.Headers.ContentType = new MediaTypeHeaderValue(image.MimeType);
           // //    multipartContent.Add(imageContent, "image" + counter++, image.FileName);
           // //}

           // var imageContent = new ByteArrayContent(eventModel.ActivityCover.FileBytes);
           //// imageContent.Headers.ContentType = new MediaTypeHeaderValue(eventModel.ActivityCover.MediaType);
           // multipartContent.Add(imageContent, "cover", eventModel.ActivityCover.FileName);

           // multipartContent.Headers.Add("Authorization", "Bearer XUQZFuPn1Obq59Fs7Q8uMuldQDox7JicsBC62LyzYFGL_dh1qF4Y9U_yn1JGSDD7W_iewJGGzf4vxyCWxRiIIl8T_amRlFrU8Aqa86TRQ1HyOoP7P7HlssiXRhVtGYo7-FFSqaeWGyWcd5wVfEBZrGDsGcd6mgi6yk221GxAqhMBTjwIsYu6j1Q3VOzgE0yVUBTOjGhV2_qQNnf4NS3H3CcvNPGXtvlBBeoq8xbV-ElcyAm7qPie5n7WDzMcWp8lWwCCKh7nW74FHdcyLTVm304SmRcd-fiw-8CcXwjCFylhNYwdJhBq-TkDzz9zxkEU9dscqjLRCKvgSmEAypb4p_fZRCF7jOQbgtrgri01I30");
           // var response = new HttpClient()
           //     .PostAsync("http://localhost:51742/api/unstartedevents/5F5D8313-BE4F-4DC5-A9EB-6F9AEC406F2E/start", multipartContent)
           //     .Result;

           // var responseContent = response.Content.ReadAsStringAsync().Result;
           // Trace.Write(responseContent);
        }
    }
}
