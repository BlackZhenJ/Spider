using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StratageModel
    {
        private static StratageModel instanse
        {
            get; set;
        }

        public static StratageModel Instanse
        {
            get
            {
                if (instanse == null)
                    instanse = new StratageModel();
                return instanse;
            }
        }

        private spiderEntities entities { get; set; }

        private static object IdLock = new object();

        public List<stratege> GetList()
        {
            return entities.stratege.Where(s => true).ToList();
        }

        public StratageModel()
        {
            entities = new spiderEntities();
        }

        public stratege GetModelById(int id)
        {
            return entities.stratege.FirstOrDefault(s => s.StaId == id);
        }

        public void SaveModel(stratege sta)
        {
            PreCheck(sta);
            entities = new spiderEntities();
            if (sta.StaId == 0)
            {
                lock (IdLock)
                {
                    sta.StaId = GetCurrentId() + 1;
                    entities.stratege.Add(sta);
                    entities.SaveChanges();
                }
            }
            else
            {
                var staData = entities.stratege.FirstOrDefault(s => s.StaId == sta.StaId);
                Clone(sta, staData);
                entities.SaveChanges();
            }
        }

        private void Clone(stratege source, stratege target)
        {
            target.StaName = source.StaName;
            target.StaRootUrl = source.StaRootUrl;
            target.StaDeep = source.StaDeep;
        }

        private void PreCheck(stratege sta)
        {
            if (sta.StaId == 0 && entities.stratege.Any(s => s.StaName == sta.StaName))
                throw new Exception("Name Existed！");
        }

        private int GetCurrentId()
        {
            var max = entities.stratege.Where(s => true).OrderByDescending(s => s.StaId).FirstOrDefault();
            return max == null ? 1 : max.StaId + 1;
        }

        public void Delete(int id)
        {
            var sta = entities.stratege.FirstOrDefault(s => s.StaId == id);
            entities.stratege.Remove(sta);
            entities.SaveChanges();
        }
    }
}
