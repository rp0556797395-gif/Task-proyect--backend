//using Microsoft.AspNetCore.Mvc;
//using Proyect;
//using Proyect.Controllers;
//using Proyect.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TaskProject1
//{
//    public class ClientControllerTest
//    {
//        private FakeContext fakeContext = new FakeContext();

//        [Fact]
//        public void Get_ReturnList()
//        {
//            //AAA
//            //arrange

//            //act
//            var controller = new ClientsController(fakeContext);
//            var result = controller.Get();

//            //assert
//            Assert.IsType<List<Clients>>(result);
//        }
     
      
//        [Fact]
//        public void GetById_ReturnOk()
//        {
//            //AAA
//            //arrange - בחלק זה נרשום את הנתונים שנצרכים להפעלת הפונקציה
//            var id = 1;
//            //act - בחלק זה נפעיל את הפונקציה
//            var controller = new ClientsController(fakeContext);
//            var result = controller.Get(id);

//            //assert - בחלק זה נכריז על התוצאה שאנחנו מצפות לקבל
//            Assert.IsType<OkObjectResult>(result);
//        }

//        [Fact]
//        public void GetById_ReturnNotFount()
//        {
//            //AAA
//            //arrange - בחלק זה נרשום את הנתונים שנצרכים להפעלת הפונקציה
//            var id = 2;
//            //act - בחלק זה נפעיל את הפונקציה
//            var controller = new ClientsController(fakeContext);
//            var result = controller.Get(id);

//            //assert - בחלק זה נכריז על התוצאה שאנחנו מצפות לקבל
//            Assert.IsType<NotFoundResult>(result);
//        }
//        [Fact]
//        public void Post_AddClient()
//        {

//            var controller = new ClientsController(fakeContext);
//            Clients newc = new Clients { Id = 3, Name = "aaa", adress = "ewryu", mail = "shhj" };
//            var result = controller.Post(newc);

//            Assert.IsType<OkObjectResult>(result);

//        }
//        [Fact]
//        public void Put_Client()
//        {
//            var id =1;
//            Clients f = new Clients { Id = 1, Name = "aaa", adress = "ewryu", mail = "shhj" };
//            var controller = new ClientsController(fakeContext);
//            var result = controller.Put(id, f);
//            Assert.IsType<OkObjectResult>(result);
//        }
//        [Fact]
//        public void Delete_client()
//        {
//            var id = 1;
//            var controller = new ClientsController(fakeContext);
//            var result = controller.Delete(id);
//            Assert.IsType<NoContentResult>(result);
//        }



//    }
//}
