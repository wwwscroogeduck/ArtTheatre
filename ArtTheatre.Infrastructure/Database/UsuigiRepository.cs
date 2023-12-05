﻿using ArtTheatre.Infrastructure.Mappers;
using ArtTheatre.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ArtTheatre.Infrastructure.Database
{
    public class UsuigiRepository
    {
        public List<UslusgiViewModel> GetList()
        {
            using (var context = new Context())
            {
                var items = context.uslugi.ToList();
                return UslugiMapper.Map(items);
            }
        }

        public UslusgiViewModel GetById(long id)
        {
            using (var context = new Context())
            {
                var item = context.uslugi.FirstOrDefault(x => x.id == id);
                return UslugiMapper.Map(item);
            }
        }
        public UslusgiViewModel Update(UslusgiViewModel entity) // метод редактирования существующей записи клиента в бд
        {
            entity.name = entity.name.Trim();
            if (string.IsNullOrEmpty(entity.name))
                MessageBox.Show("Имя Пользователя не может быть пустым");

            using (var context = new Context())
            {
                var item = context.uslugi.FirstOrDefault(x => x.id == entity.id);
                if (item != null)
                {
                    item.name = entity.name;
                    item.cost = entity.cost;
                    context.SaveChanges();
                }
                else
                {
                    System.Windows.MessageBox.Show("");
                    MessageBox.Show("Ничего не было сохранено");
                }
                return UslugiMapper.Map(item);
            }
        }
        public UslusgiViewModel Add(UslusgiViewModel entity) // метод добавления клиента в бд
        {
            entity.name = entity.name.Trim();
            entity.cost = entity.cost;
            if (string.IsNullOrEmpty(entity.name) || entity.cost == null)
            {
                throw new Exception("Название Услуги не может быть пустым");
            }
            using (var context = new Context())
            {
                var item = UslugiMapper.Map(entity);
                context.uslugi.Add(item);
                if (item != null)
                {
                    item.name = entity.name;
                    item.cost = entity.cost;
                    context.uslugi.Add(item);
                    context.SaveChanges();
                    MessageBox.Show("Успешное Сохранение");
                }
                else
                {
                    MessageBox.Show("Ничего не было сохранено");
                }
                return UslugiMapper.Map(item);
            }
        }

        public void Delete(long id) // метод удаления существующей записи клиента в бд
        {
            // удаляем клиента
            using (var context = new Context())
            {
                var user = context.uslugi.FirstOrDefault(x => x.id == id);
                if (user != null)
                {
                    context.uslugi.Remove(user);
                    context.SaveChanges();
                }
            }
        }
        public List<UslusgiViewModel> Search(string search) // метод поиска существующей записи клиента в грид
        {
            search = search.Trim();
            using (var context = new Context())
            {
                var result = context.uslugi.Where(x => x.name.Contains(search) && x.name.StartsWith(search) || x.cost.ToString().StartsWith(search)).ToList();
                return UslugiMapper.Map(result);
            }
        }
    }
}
