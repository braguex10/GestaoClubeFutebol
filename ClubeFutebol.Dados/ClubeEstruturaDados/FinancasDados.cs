/*
*	<copyright file="FinancasDados.cs"
*		Copyright (c) 2025 All Rights Reserved
*	</copyright>
* 	<author>a31508goncalobraga</author>
*	<description></description>
**/

using System.Collections.Generic;
using ClubeFutebol.BOO.ClubeEstrutura;
using ClubeFutebol.BOO.Pessoas;
using ClubeFutebol.Dados.Interfaces;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace ClubeFutebol.Dados.ClubeEstrutura
{
    public class FinancasDados : InterfaceFinancasDados
    {
        #region Atributos

        private readonly List<Financas> listaFinancas;

        private readonly Dictionary<Financas, Dictionary<Pessoa, float>> salarios;
        private readonly Dictionary<Financas, Dictionary<Pessoa, float>> valoresMercado;

        #endregion

        #region Construtor

        public FinancasDados()
        {
            listaFinancas = new List<Financas>();
            salarios = new Dictionary<Financas, Dictionary<Pessoa, float>>();
            valoresMercado = new Dictionary<Financas, Dictionary<Pessoa, float>>();
        }

        #endregion

        #region Gestão Geral

        public bool InserirFinancas(Financas f)
        {
            if (f == null || listaFinancas.Contains(f))
                return false;

            listaFinancas.Add(f);
            salarios[f] = new Dictionary<Pessoa, float>();
            valoresMercado[f] = new Dictionary<Pessoa, float>();
            return true;
        }

        public bool RemoverFinancas(Financas f)
        {
            if (!listaFinancas.Remove(f))
                return false;

            salarios.Remove(f);
            valoresMercado.Remove(f);
            return true;
        }

        public bool ExisteFinancas(Financas f)
        {
            return listaFinancas.Contains(f);
        }

        #endregion

        #region Saldo e Orçamentos

        public bool AtualizarSaldo(Financas f, float valor)
        {
            if (!ExisteFinancas(f))
                return false;

            f.SaldoClube = valor;
            return true;
        }

        public bool AtualizarOrcamentoSalarios(Financas f, float valor)
        {
            if (!ExisteFinancas(f))
                return false;

            f.OrcamentoSalarios = valor;
            return true;
        }

        public bool AtualizarOrcamentoTransferencias(Financas f, float valor)
        {
            if (!ExisteFinancas(f))
                return false;

            f.OrcamentoTransferencias = valor;
            return true;
        }

        #endregion

        #region Salários

        public bool DefinirSalario(Financas f, Pessoa p, float valor)
        {
            if (!ExisteFinancas(f) || p == null)
                return false;

            salarios[f][p] = valor;
            return true;
        }

        public bool RemoverSalario(Financas f, Pessoa p)
        {
            if (!ExisteFinancas(f) || p == null)
                return false;

            return salarios[f].Remove(p);
        }

        public float ObterSalario(Financas f, Pessoa p)
        {
            if (!ExisteFinancas(f) || p == null)
                return 0f;

            if (!salarios[f].ContainsKey(p))
                return 0f;

            return salarios[f][p];
        }

        public float TotalSalarios(Financas f)
        {
            if (!ExisteFinancas(f))
                return 0f;

            float total = 0f;
            foreach (float valor in salarios[f].Values)
                total += valor;

            return total;
        }

        #endregion

        #region Valores de Mercado

        public bool DefinirValorMercado(Financas f, Pessoa p, float valor)
        {
            if (!ExisteFinancas(f) || p == null)
                return false;

            if (!valoresMercado.ContainsKey(f))
                valoresMercado[f] = new Dictionary<Pessoa, float>();

            if (!valoresMercado[f].ContainsKey(p))
                valoresMercado[f].Add(p, valor);
            else
                valoresMercado[f][p] = valor;

            return true;
        }


        public bool RemoverValorMercado(Financas f, Pessoa p)
        {
            if (!ExisteFinancas(f) || p == null)
                return false;

            return valoresMercado[f].Remove(p);
        }

        public float ObterValorMercado(Financas f, Pessoa p)
        {
            if (!ExisteFinancas(f) || p == null)
                return 0f;

            if (!valoresMercado[f].ContainsKey(p))
                return 0f;

            return valoresMercado[f][p];
        }

        #endregion

        public bool GuardarFinancas(string ficheiro)
        {
            try
            {
                using (FileStream fs = new FileStream(ficheiro, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();

                    bf.Serialize(fs, listaFinancas);
                    bf.Serialize(fs, salarios);
                    bf.Serialize(fs, valoresMercado);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool LerFinancas(string ficheiro)
        {
            if (!File.Exists(ficheiro))
                return false;

            try
            {
                using (FileStream fs = new FileStream(ficheiro, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();

                    listaFinancas.Clear();
                    salarios.Clear();
                    valoresMercado.Clear();

                    var lista = (List<Financas>)bf.Deserialize(fs);
                    var sal = (Dictionary<Financas, Dictionary<Pessoa, float>>)bf.Deserialize(fs);
                    var mercado = (Dictionary<Financas, Dictionary<Pessoa, float>>)bf.Deserialize(fs);

                    listaFinancas.AddRange(lista);

                    foreach (var s in sal)
                        salarios.Add(s.Key, s.Value);

                    foreach (var v in mercado)
                        valoresMercado.Add(v.Key, v.Value);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
