﻿using App2.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace App2.Layers.Service
{
    public class JogadoresService
    {
        public IList<DateModel> GetJogadoresFromSalesForce()
        {
            var uri = "https://www.reqres.in/api/unknown";

            HttpClient client = new HttpClient();
            var resposta = client.GetAsync(uri).Result;

            if (resposta.IsSuccessStatusCode)
            {
                var resultado = resposta.Content.ReadAsStringAsync().Result;
                var jogadores = JsonConvert.DeserializeObject<JogadoresModel>(resultado);

                return jogadores.Data;
            }
            else
            {
                throw new Exception("Perfis não encontrados!");
            }


        }
        public void SaveJogadoresOnSalesForce(JogadorSalesForceModel jogadorSalesForce)
        {
            var _urlAccountApi = "https://na49.salesforce.com/services/data/v43.0/sobjects/";

            var _body = JsonConvert.SerializeObject(jogadorSalesForce);

            StringContent _conteudo = new StringContent(_body, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Global.TokenSalesForce.access_token);
            var response = client.PostAsync(_urlAccountApi, _conteudo).Result;

            if (response.IsSuccessStatusCode)
            {
                var conteudoResposta = response.Content.ReadAsStringAsync().Result;
                dynamic json = JsonConvert.DeserializeObject(conteudoResposta);
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }

        }
    }
}
