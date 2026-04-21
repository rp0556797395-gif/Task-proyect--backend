//using Microsoft.AspNetCore.Mvc;
//using Proyect.Controllers;
//using Proyect.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TaskProject1
//{
//    public class TaskControllerTest
//    {
//        private FakeContext fakeContext = new FakeContext();

//        [Fact]
//        public void Get_ReturnList()
//        {
//            //AAA
//            //arrange

//            //act
//            var controller = new TasksController(fakeContext);
//            var result = controller.Get();

//            //assert
//            Assert.IsType<List<Tasks>>(result);
//        }
      
//        [Fact]
//        public void GetById_ReturnOk()
//        {
//            //AAA
//            //arrange - בחלק זה נרשום את הנתונים שנצרכים להפעלת הפונקציה
//            var id = 1;
//            //act - בחלק זה נפעיל את הפונקציה
//            var controller = new TasksController(fakeContext);
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
//            var controller = new TasksController(fakeContext);
//            var result = controller.Get(id);

//            //assert - בחלק זה נכריז על התוצאה שאנחנו מצפות לקבל
//            Assert.IsType<NotFoundResult>(result);
//        }


//        [Fact]
//        public void Post_AddTask()
//        {

//            var controller = new TasksController(fakeContext);
//            Tasks newc = new Tasks { code = 2, Name = "Chana", IsCompleted = false, Category = Category.Home };
//            var result = controller.Post(newc);

//            Assert.IsType<OkObjectResult>(result);

//        }
//        [Fact]
//        public void Put_Tasks()
//        {
//            var id = 1;
//            Tasks f = new Tasks { code = 1, Name = "Chana", IsCompleted = false, Category = Category.Home };
//            var controller = new TasksController(fakeContext);
//            var result = controller.Put(id, f);
//            Assert.IsType<OkObjectResult>(result);
//        }
//        [Fact]
//        public void Delete_Task()
//        {
//            var id = 1;
//            var controller = new TasksController(fakeContext);
//            var result = controller.Delete(id);
//            Assert.IsType<NoContentResult>(result);
//        }





//    }
//}
