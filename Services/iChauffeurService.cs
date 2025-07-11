using Api_AgenceVoyage.Entities;
using Api_AgenceVoyage.Helpers;
using Api_AgenceVoyage.Models.Chauffeur;
using AutoMapper;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Api_AgenceVoyage.Services
{
    public interface iChauffeurService
    {
        IEnumerable<Chauffeur> GetAll();
        Chauffeur GetById(int id);
        void Create(CreateRequests model);
        void Update(int id, UpdateRequests model);
        void Delete(int id);
    }

    public class ChauffeurService : iChauffeurService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        private readonly IDatabase _redisDb;


        public ChauffeurService( DataContext context,IMapper mapper, IConnectionMultiplexer redis)
        {
            _context = context;
            _mapper = mapper;
            _redisDb = redis.GetDatabase();
        }

        public IEnumerable<Chauffeur> GetAll()
        {
            // Vérifier si la liste des chauffeurs est déjà en cache
            var cached = _redisDb.StringGet("chauffeurs:list");
            if (cached.HasValue)
            {
                Console.WriteLine("Données récupérées depuis Redis");
                return JsonConvert.DeserializeObject<List<Chauffeur>>(cached);
            }

            Console.WriteLine(" Données récupérées depuis PostgreSQL (cache vide)");


            // Sinon, charger depuis la base
            var chauffeurs = _context.Chauffeurs.ToList();

            // Mettre en cache pour 30 minutes
            _redisDb.StringSet("chauffeurs:list", JsonConvert.SerializeObject(chauffeurs), TimeSpan.FromMinutes(30));

            return chauffeurs;
        }

        public void Create(CreateRequests model)
        {
            var chauffeur = _mapper.Map<Chauffeur>(model);
            _context.Chauffeurs.Add(chauffeur);
            _context.SaveChanges();



        }

        public void Update(int id, UpdateRequests model)
        {
            var chauffeur = getCahuffeur(id);
            _mapper.Map(model, chauffeur);
            _context.Chauffeurs.Update(chauffeur);
            _context.SaveChanges();

            // Invalider le cache
            _redisDb.KeyDelete("chauffeurs:list");

        }

        public Chauffeur GetById(int id)
        {
            return getCahuffeur(id);
        }

        private Chauffeur getCahuffeur(int id)
        {
            var Chauffeur = _context.Chauffeurs.Find(id);
            if (Chauffeur == null) throw new KeyNotFoundException("Chauffeurs not found");
            return Chauffeur;
        }

        public void Delete(int id)
        {
            var Chauffeur = getCahuffeur(id);
            _context.Chauffeurs.Remove(Chauffeur);
            _context.SaveChanges();

            // Invalider le cache
            _redisDb.KeyDelete("chauffeurs:list");

        }
    }
}
