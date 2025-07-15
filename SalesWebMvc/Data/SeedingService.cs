using System;
using Microsoft.EntityFrameworkCore.Internal;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;
using SalesWebMvc.Models.ViewModels;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {


        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Departament.Any() || _context.Seller.Any() || _context.SallesRecord.Any())
            {
                return;// DB has been seeded
            }

            Departament d1 = new Departament(1, "Computers");
            Departament d2 = new Departament(2, "Eletronics");
            Departament d3 = new Departament(3, "Fashion");
            Departament d4 = new Departament(4, "Books");

            Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Seller s2 = new Seller(2, "Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 3500.0, d2);
            Seller s3 = new Seller(3, "Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 15), 2200.0, d1);
            Seller s4 = new Seller(4, "Martha Red", "martha@gmail.com", new DateTime(1993, 11, 30), 3000.0, d4);
            Seller s5 = new Seller(5, "Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9), 4000.0, d3);
            Seller s6 = new Seller(6, "Alex Pink", "bob@gmail.com", new DateTime(1997, 3, 4), 3000.0, d2);

            SallesRecord r1 = new SallesRecord(1, new DateTime(2018, 09, 25), 11000.0, SalleStatus.Billed, s1);
            SallesRecord r2 = new SallesRecord(2, new DateTime(2018, 09, 4), 7000.0, SalleStatus.Billed, s5);
            SallesRecord r3 = new SallesRecord(3, new DateTime(2018, 09, 13), 4000.0, SalleStatus.Canceled, s4);
            SallesRecord r4 = new SallesRecord(4, new DateTime(2018, 09, 1), 8000.0, SalleStatus.Billed, s1);
            SallesRecord r5 = new SallesRecord(5, new DateTime(2018, 09, 21), 3000.0, SalleStatus.Billed, s3);
            SallesRecord r6 = new SallesRecord(6, new DateTime(2018, 09, 15), 2000.0, SalleStatus.Billed, s1);
            SallesRecord r7 = new SallesRecord(7, new DateTime(2018, 09, 28), 13000.0, SalleStatus.Billed, s2);
            SallesRecord r8 = new SallesRecord(8, new DateTime(2018, 09, 11), 4000.0, SalleStatus.Billed, s4);
            SallesRecord r9 = new SallesRecord(9, new DateTime(2018, 09, 14), 11000.0, SalleStatus.Pending, s6);
            SallesRecord r10 = new SallesRecord(10, new DateTime(2018, 09, 7), 9000.0, SalleStatus.Billed, s6);
            SallesRecord r11 = new SallesRecord(11, new DateTime(2018, 09, 13), 6000.0, SalleStatus.Billed, s2);
            SallesRecord r12 = new SallesRecord(12, new DateTime(2018, 09, 25), 7000.0, SalleStatus.Pending, s3);
            SallesRecord r13 = new SallesRecord(13, new DateTime(2018, 09, 29), 10000.0, SalleStatus.Billed, s4);
            SallesRecord r14 = new SallesRecord(14, new DateTime(2018, 09, 4), 3000.0, SalleStatus.Billed, s5);
            SallesRecord r15 = new SallesRecord(15, new DateTime(2018, 09, 12), 4000.0, SalleStatus.Billed, s1);
            SallesRecord r16 = new SallesRecord(16, new DateTime(2018, 10, 5), 2000.0, SalleStatus.Billed, s4);
            SallesRecord r17 = new SallesRecord(17, new DateTime(2018, 10, 1), 12000.0, SalleStatus.Billed, s1);
            SallesRecord r18 = new SallesRecord(18, new DateTime(2018, 10, 24), 6000.0, SalleStatus.Billed, s3);
            SallesRecord r19 = new SallesRecord(19, new DateTime(2018, 10, 22), 8000.0, SalleStatus.Billed, s5);
            SallesRecord r20 = new SallesRecord(20, new DateTime(2018, 10, 15), 8000.0, SalleStatus.Billed, s6);
            SallesRecord r21 = new SallesRecord(21, new DateTime(2018, 10, 17), 9000.0, SalleStatus.Billed, s2);
            SallesRecord r22 = new SallesRecord(22, new DateTime(2018, 10, 24), 4000.0, SalleStatus.Billed, s4);
            SallesRecord r23 = new SallesRecord(23, new DateTime(2018, 10, 19), 11000.0, SalleStatus.Canceled, s2);
            SallesRecord r24 = new SallesRecord(24, new DateTime(2018, 10, 12), 8000.0, SalleStatus.Billed, s5);
            SallesRecord r25 = new SallesRecord(25, new DateTime(2018, 10, 31), 7000.0, SalleStatus.Billed, s3);
            SallesRecord r26 = new SallesRecord(26, new DateTime(2018, 10, 6), 5000.0, SalleStatus.Billed, s4);
            SallesRecord r27 = new SallesRecord(27, new DateTime(2018, 10, 13), 9000.0, SalleStatus.Pending, s1);
            SallesRecord r28 = new SallesRecord(28, new DateTime(2018, 10, 7), 4000.0, SalleStatus.Billed, s3);
            SallesRecord r29 = new SallesRecord(29, new DateTime(2018, 10, 23), 12000.0, SalleStatus.Billed, s5);
            SallesRecord r30 = new SallesRecord(30, new DateTime(2018, 10, 12), 5000.0, SalleStatus.Billed, s2);

            _context.Departament.AddRange(d1, d2, d3,d4);
            _context.Seller.AddRange(s1,s2,s3,s4,s5,s6);
            _context.SallesRecord.AddRange(
             r1, r2, r3, r4, r5, r6, r7, r8, r9, r10,
             r11, r12, r13, r14, r15, r16, r17, r18, r19, r20,
             r21, r22, r23, r24, r25, r26, r27, r28, r29, r30
         );


            _context.SaveChanges();
        }
    }
}
