using Gremlin.Net.Process.Traversal;
using IPTreatment.Controllers;
using IPTreatment.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using static IPTreatment.Models.PatientDetail;

namespace IPTreatmentUnitTesting
{
    public class Tests
    {
        List<TreatmentPlan> treatment = new List<TreatmentPlan>
        {
            new TreatmentPlan
            {
                PackageName="Package_1",
                TestDetails="OPT1, OPT2",
                Cost=2500,
                Specialist="Dr.Gupta",
                CommencementDate=Convert.ToDateTime("2020-07-22"),
                EndDate=Convert.ToDateTime("2020-07-22")
            }

        };
        PatientDetail patient = new PatientDetail();
        

        FormulateTreatmentTimetableController con1 = new FormulateTreatmentTimetableController();
        [SetUp]
        public void Setup()
        {
            var plan = treatment.AsQueryable();
            var mockset = new Mock<TreatmentPlan>();
            mockset.As<IQueryable<TreatmentPlan>>().Setup(m => m.Provider).Returns(plan.Provider);
            mockset.As<IQueryable<TreatmentPlan>>().Setup(m => m.Expression).Returns(plan.Expression);
            mockset.As<IQueryable<TreatmentPlan>>().Setup(m => m.ElementType).Returns(plan.ElementType);
            mockset.As<IQueryable<TreatmentPlan>>().Setup(m => m.GetEnumerator()).Returns(plan.GetEnumerator());
        }

        [Test]
        public void Test1()
        {
            
           var result = con1.Post(new PatientDetail { PatientName = "Ankit", Age = 21, Ailment = "Urology", Packages = Package.Package1, Date = Convert.ToDateTime("2020-07-22") });
            var type1 = result;
            // Console.WriteLine(result);

            // Console.WriteLine(iptreatment);

            var type2 = treatment as List<TreatmentPlan>;
            Assert.IsNotNull(type1);
            Assert.Pass();
        }
    }
}