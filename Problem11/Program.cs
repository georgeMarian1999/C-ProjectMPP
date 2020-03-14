using System;
using Problem11.Repositories;
using Problem11.Model;
namespace Problem11
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            AngajatRepository angajat = new AngajatRepository();
            Console.WriteLine(angajat.findOne(1).User);
            CursaRepository cursa = new CursaRepository();
            Console.WriteLine(cursa.findOne(1).Capacitate);
            EchipaRepository echipaRepository = new EchipaRepository();
            Console.WriteLine(echipaRepository.findOne(25).Nume);
            ParticipantRepository participant = new ParticipantRepository();
            Console.WriteLine(participant.findOne(1).Nume);

            Cursa C = new Cursa(100,900);
            cursa.save(C);
            Console.WriteLine(cursa.findOne(100).Capacitate);

            Echipa E = new Echipa(200, "test");
            echipaRepository.save(E);
            Console.WriteLine(echipaRepository.findOne(200).Nume);

            Participant P = new Participant(600, "test1", 200);
            participant.save(P);
            Console.WriteLine(participant.findOne(600).Nume);

            cursa.delete(100);
            echipaRepository.delete(200);
            participant.delete(600);




        }
    }
}
