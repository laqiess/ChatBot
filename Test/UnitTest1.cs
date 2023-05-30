using Chat;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod_set_get()
        {
            ChatB f = new ChatB();

            f.username_set("rew");
            Assert.AreEqual("rew", f.username_get());

            f.username_set("pol");
            Assert.AreEqual("pol", f.username_get());

            f.username_set("gty");
            Assert.AreEqual("gty", f.username_get());
        }

        [TestMethod]
        public void TestMethod_answer()
        {
            ChatB f = new ChatB();

            Assert.AreEqual("«дравствуй", f.answer("ѕривет"));
            Assert.AreEqual("«дравствуй", f.answer("п–ив"));
            Assert.AreEqual("«дравствуй", f.answer("приветик"));

            Assert.AreEqual(DateTime.Now.ToString("T"), f.answer("часов"));
            Assert.AreEqual(DateTime.Now.ToString("T"), f.answer("времени"));
            Assert.AreEqual(DateTime.Now.ToString("T"), f.answer("врећ€"));

            Assert.AreEqual(DateTime.Now.ToString("D"), f.answer("дата"));
            Assert.AreEqual(DateTime.Now.ToString("D"), f.answer("число"));
            Assert.AreEqual(DateTime.Now.ToString("D"), f.answer("ƒень"));

            Assert.AreEqual(21, Int32.Parse(f.answer("сложи 12 и 9")));
            Assert.AreEqual(72, Int32.Parse(f.answer("сложи 0 и 72")));

            Assert.AreEqual(108, Int32.Parse(f.answer("умножь 12 и 9")));
            Assert.AreEqual(-18, Int32.Parse(f.answer("умножь 6 и -3")));

            Assert.AreEqual(3.0, Int32.Parse(f.answer("разность 12 и 9")));
            Assert.AreEqual(-8, Int32.Parse(f.answer("разность 0 и 8")));

            Assert.AreEqual(1.3333, float.Parse(f.answer("раздели 12 и 9")), 0.0001);
            Assert.AreEqual(4, float.Parse(f.answer("подели 100 и 25")), 0.0001);

            Assert.AreEqual("запрос не определен,попробуйте снова", f.answer("zdgfsdg"));
        }
    }

   
}