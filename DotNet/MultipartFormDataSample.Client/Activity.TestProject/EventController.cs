using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Activity.TestProject.Helpers;
using Activity.TestProject.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Activity.TestProject
{
    [TestClass]
    public class EventController : BaseTest
    {
        #region GetActivityById //Done
        [TestMethod]
        public void GetActivityById_EmbedMates()
        {
            string url = this.HostName + "events/240407FB-FE05-4E36-8574-BF8FD0F17090?embed=mates";
            var result = CustomerHttpClient.Instance.SendGetRequest(url, this.Token);
            Debug.Write(result);
        }

        [TestMethod]
        public void GetActivityById_EmbedFollows()
        {
            string url = this.HostName + "events/240407FB-FE05-4E36-8574-BF8FD0F17090?embed=follows";
            var result = CustomerHttpClient.Instance.SendGetRequest(url, this.Token);
            Debug.Write(result);
            //Done
        }

        [TestMethod]
        public void GetActivityById_All()
        {
            string url = this.HostName + "events/240407FB-FE05-4E36-8574-BF8FD0F17090?embed=follows,mates";
            var result = CustomerHttpClient.Instance.SendGetRequest(url, this.Token);
            Debug.Write(result);
            //Done
        }

        #endregion

        #region GetActivityByGeo

        [TestMethod]
        public void GetActivityByGeo_ByPager()
        {
            string url = this.HostName + "/events?organizer=" + this.CurrentId + "&page=1&per_page=20";
            var result = CustomerHttpClient.Instance.SendGetRequest(url, this.Token);
            Debug.Write(result);
            //mate不为空时有错误

        }


        #endregion

        #region GetPaticipants  //Done

        [TestMethod]
        public void GetPaticipants_ByPager()
        {
            string url = this.HostName + "events/240407FB-FE05-4E36-8574-BF8FD0F17090/mates?page=1&per_page=20";
            var result = CustomerHttpClient.Instance.SendGetRequest(url, this.Token);
            Debug.Write(result);

        }

        #endregion

        #region Getfollows //Done

        [TestMethod]
        public void Getfollows_ByPager()
        {
            string url = this.HostName + "events/240407FB-FE05-4E36-8574-BF8FD0F17090/follows?page=1&per_page=20";
            var result = CustomerHttpClient.Instance.SendGetRequest(url, this.Token);
            Debug.Write(result);

        }

        #endregion

        #region GetMatchedUnStartedActivity 未完成

        [TestMethod]
        public void GetMatchedUnStartedActivity_Test()
        {
            string url = this.HostName + "unstartedevents?temporaryCode";
            var result = CustomerHttpClient.Instance.SendGetRequest(url, this.Token);
            Debug.Write(result);

        }

        #endregion

        #region GetUnStartedActivity --Done

        [TestMethod]
        public void GetUnStartedActivity_Test()
        {
            string url = this.HostName + "unstartedevents/4E5F591B-F1E2-4AF3-9B27-36251989412F";
            var result = CustomerHttpClient.Instance.SendGetRequest(url, this.Token);
            Debug.Write(result);
        }

        #endregion

        [TestMethod]
        public void GetEventMates()
        {
            string url = this.HostName + "events/mates?eid=FCF618A7-C89A-4C59-9EA0-4B93C00D44D9&page=1&per_page=10";
            var result = CustomerHttpClient.Instance.SendGetRequest(url, this.Token);
            Debug.Write(result);
        }


        #region CreateUnstartedActivity  //Done
        [TestMethod]
        public void CreateUnstartedActivity_Test()
        {
            var createActivityModel = new CreateUnstartEventModel()
            {
                Organizer = this.CurrentId,
                Location = new LocationModel()
                {
                    Latitude = 109,
                    Longitude = 112,
                    DisplayName = "青白江区",
                }
            };
            var url = this.HostName + "unstartedevents";
            var result = CustomerHttpClient.Instance.SendPostRequest(url, createActivityModel, this.Token);

            Debug.WriteLine(result);

        }
        #endregion

        #region AddParticipantsToUnStartedActivity  //Done
        [TestMethod]
        public void AddParticipantsToUnStartedActivity_Test()
        {
            var url = this.HostName + "unstartedevents/8aacbdbf-7f6d-4944-8e2e-9c397a5a33f8";
            var mate = new AddParticipantModel()
                           {
                               MateId = Guid.Parse("8CFA1DE3-AA10-4BD6-97BD-A67B5A14345F"),
                               UserId = this.CurrentId
                           };
            var result = CustomerHttpClient.Instance.SendPutRequest(url, mate, this.Token);
            Debug.WriteLine(result);

        }

        #endregion

        #region   StartActivity  //Done
         [TestMethod]
        public void StartActivity_Test()
        {
            string url = this.HostName + "/unstartedevents/8aacbdbf-7f6d-4944-8e2e-9c397a5a33f8/start";
            var model = new StartUnstartEventModel()
                            {
                                ActivityCover = Directory
                                    .EnumerateFiles("../../../../../SampleImages")
                                    .Where(file => new[] {".jpg", ".png"}.Contains(Path.GetExtension(file)))
                                    .Select(file => new FileModel()
                                                        {
                                                            FileName = Path.GetFileName(file),
                                                            FileType = FileType.Image,
                                                            FileBytes = File.ReadAllBytes(file)
                                                        }).First(),
                                ActivityName = "我很冷，求安慰",
                                Participants = new List<Guid>()
                                                   {
                                                       Guid.Parse("8CFA1DE3-AA10-4BD6-97BD-A67B5A14345F"),
                                                       Guid.Parse("C3BBE387-8665-4294-A93F-ACBBE97663D7")
                                                   },
                                Weather = 2
                            };
            var reuslt = CustomerHttpClient.Instance.SendPutRequest(url, model, this.Token);
            Debug.WriteLine(reuslt);
        }

        #endregion

        #region UpdateActivity //Done

        public void UpdateActivity_Test()
        {
            string url = this.HostName + "events/8aacbdbf-7f6d-4944-8e2e-9c397a5a33f8";
            var model = new UpdateActivityModel
                            {
                                ActivityCover = Directory
                                    .EnumerateFiles("../../../../../SampleImages")
                                    .Where(file => new[] {".jpg", ".png"}.Contains(Path.GetExtension(file)))
                                    .Select(file => new FileModel()
                                                        {
                                                            FileName = Path.GetFileName(file),
                                                            FileType = FileType.Image,
                                                            FileBytes = File.ReadAllBytes(file)
                                                        }).Last()
                            };
            var result = CustomerHttpClient.Instance.SendPutRequest(url, model, this.Token);
            Debug.WriteLine(result);
        }

        #endregion
    }
}
