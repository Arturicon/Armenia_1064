﻿using GameSystems;
using Model.Entities.Answers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace Assets.Game.HappeningSystem.Persons
{
    public class RelationManager : IEnumerable<Relation>
    {
        private readonly List<Relation> relations = new List<Relation>();

        public void ChangeRelation(SinglePersonConsequences personConsequences)
        {
            var relation = relations.FirstOrDefault(x => x.Name == personConsequences.PersonName.Name);
            if (relation != null)
            {
                relation.Value.Value = Mathf.Max(relation.Value.Value + personConsequences.Value, 0);
                Logger.WriteLog($"Relation. {personConsequences.PersonName.Name} - {personConsequences.Value}");
            }
        }

        public int GetRelation(string person)
        {
            return relations.FirstOrDefault(x => x.Name == person).Value.Value;
        }

        public void InitPersonRelation(string person, int value)
        {
            if (relations.Any(x => x.Name == person))
            {
                var pers = relations.First(x => x.Name == person);
                pers.Value.Value = value;
            }
            else
            {
                var relation = new Relation();
                relation.Name = person;
                relation.Value.Value = value;
                relations.Add(relation);
            }
        }


        public void Clear()
        {
            relations.Clear();
        }

        public IEnumerator<Relation> GetEnumerator()
        {
            return ((IEnumerable<Relation>)relations).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)relations).GetEnumerator();
        }
    }
}