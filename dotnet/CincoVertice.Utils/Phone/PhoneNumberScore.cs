using AutoMapper;
using Ganss.Excel;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CincoVertice.Utils.Phone
{
    public class PhoneNumberScore
    {

        public List<PhoneModel> PhonesList = new();

        public List<PhoneScoreRuleModel> phoneScoreRuleModels = new();

        public PhoneNumberScore(string rulesFile)
        {
            LoadRules(rulesFile);
        }

        public void LoadRules(string file)
        {
            phoneScoreRuleModels = new ExcelMapper(file).Fetch<PhoneScoreRuleModel>().ToList();
        }

        public void LoadPhones(string file)
        {
            var phonesExcel = new ExcelMapper(file).Fetch<PhoneExcelModel>().ToList();

            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<PhoneExcelModel, PhoneModel>();
            });
            var mapper = new Mapper(config);

            PhonesList = mapper.Map<List<PhoneModel>>(phonesExcel);
        }

        public void Score(PhoneModel model)
        {
            foreach (var rule in phoneScoreRuleModels)
            {
                var rx = Regex.Matches(model.Phone, rule.Rule);

                if (rx.Any())
                {
                    model.Score += rx.Count * rule.Points;
                    model.Rules.Add(rule);
                }
            }
        }

        public void Save(string file)
        {
            var excel = new ExcelMapper();

            excel.AddMapping<PhoneModel>("Rules", p => p.Rules).AsJson();

            excel.Save(file, PhonesList, "Phones");
        }
    }
}
