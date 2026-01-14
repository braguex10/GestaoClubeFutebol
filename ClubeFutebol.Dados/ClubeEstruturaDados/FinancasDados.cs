/*
*	<copyright file="FinancasDados.cs"
*		Copyright (c) 2025 All Rights Reserved
*	</copyright>
* 	<author>a31508goncalobraga</author>
*	<description></description>
**/

using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ClubeFutebol.BOO.ClubeEstrutura;
using ClubeFutebol.BOO.Pessoas;
using ClubeFutebol.Dados.Interfaces;

namespace ClubeFutebol.Dados.ClubeEstrutura
{
    /// <summary>
    /// Camada de Dados responsável pela gestão financeira do clube
    /// </summary>
    public class FinancasDados : InterfaceFinancasDados                                       // armazena os dados financeiros dependentes do clube e de pessoas
    {
        #region Atributos

        // Salários e valores de mercado associados a cada clube
        private readonly Dictionary<Clube, Dictionary<Pessoa, float>> salariosPorClube;        // dicionario que contem os salarios de cada pessoa do clube
        private readonly Dictionary<Clube, Dictionary<Pessoa, float>> valoresMercadoPorClube;  // dicionario que contem os valores de mercado de cada pessoa do clube

        #endregion

        #region Construtor

        public FinancasDados()     // inicializa a estrutura de dados
        {
            salariosPorClube = new Dictionary<Clube, Dictionary<Pessoa, float>>();
            valoresMercadoPorClube = new Dictionary<Clube, Dictionary<Pessoa, float>>();
        }

        #endregion

        #region Inicialização

        /// <summary>
        /// Inicialização pós criação do clube
        /// </summary>
        public bool InicializarClube(Clube clube)
        {
            if (clube == null)  
                return false;

            bool alterado = false;                                                               // Para saber se alteramos algo

            // Se o clube não tiver estruturas financeiras associadas, cria as estruturas
            if (!salariosPorClube.ContainsKey(clube))
            {
                salariosPorClube[clube] = new Dictionary<Pessoa, float>();
                alterado = true;                                                                   // Indicamos que fizemos a alteração
            }

            if (!valoresMercadoPorClube.ContainsKey(clube))
            {
                valoresMercadoPorClube[clube] = new Dictionary<Pessoa, float>();
                alterado = true;                                                                      // Indicamos que fizemos a alteração
            }

            // Se alteramos alguma coisa, retornamos true, caso contrário false
            return alterado;
        }
        #endregion

        #region Saldo e Orçamentos
        /// <summary>
        /// Atualiza saldo do clube
        /// </summary>
        public bool AtualizarSaldo(Clube clube, float valor)     // atualiza saldo do clube
        {
            if (clube == null)              // se nao existir clube
                return false;

            clube.Financas.SaldoClube = valor;           // atribui novo valor ao saldo
            return true;
        }
        /// <summary>
        /// Atualiza o orçamento para salarios
        /// </summary>
        public bool AtualizarOrcamentoSalarios(Clube clube, float valor)   // atualiza orcamentos para salarios
        {
            if (clube == null)              // se nao existir clube
                return false;

            clube.Financas.OrcamentoSalarios = valor;    // atribuicao do novo valor
            return true;
        }
        /// <summary>
        /// Atualiza o orcamento para transferências
        /// </summary>
        public bool AtualizarOrcamentoTransferencias(Clube clube, float valor)     // atualiza orcamento transferencias
        {
            if (clube == null)                // se o clube nao existir
                return false;

            clube.Financas.OrcamentoTransferencias = valor;    // atribuicao do novo valor
            return true;
        }

        #endregion

        #region Salários
        /// <summary>
        /// Define salário de certa pessoa
        /// </summary>
        public bool DefinirSalario(Clube clube, Pessoa pessoa, float valor)    // define salario de uma pessoa do clube
        {
            if (clube == null || pessoa == null)    // se o clube ou a pessoa nao existirem
                return false;

            salariosPorClube[clube][pessoa] = valor;     // define o valor
            return true;
        }
        /// <summary>
        /// Remove salário de certa pessoa
        /// </summary>
        public bool RemoverSalario(Clube clube, Pessoa pessoa)    // remove salario da pessoa do clube
        {
            if (clube == null || pessoa == null)     // se o clube ou a pessoa nao existirem
                return false;

            return salariosPorClube[clube].Remove(pessoa);
        }
        /// <summary>
        /// Devolve o salário de alguém
        /// </summary>
        public float ObterSalario(Clube clube, Pessoa pessoa)   // obtem salario de uma pessoa
        {
            if (clube == null || pessoa == null)       // se o clube ou a pessoa nao existirem
                return 0f;

            if (!salariosPorClube[clube].ContainsKey(pessoa))     // nao existe a pessoa nos salarios do clube
                return 0f;

            return salariosPorClube[clube][pessoa];     // devolve o salario da pessoa
        }
        /// <summary>
        /// Devolve o total de salários
        /// </summary>
        public float TotalSalarios(Clube clube)  // devolve o total de salarios do clube
        {
            if (clube == null)      // se o clube nao existir
                return 0f;

            float total = 0f;                                      // define valor como 0
            foreach (float valor in salariosPorClube[clube].Values)    // percorre o dicionario e soma os valores
                total += valor;

            return total;
        }

        #endregion

        #region Valores de Mercado
        /// <summary>
        /// Define o valor de mercado da pessoa
        /// </summary>
        public bool DefinirValorMercado(Clube clube, Pessoa pessoa, float valor)       // define valor de mercado da pessoa
        {
            if (clube == null || pessoa == null)       // se o clube ou a pessoa nao existirem
                return false;

            valoresMercadoPorClube[clube][pessoa] = valor;     // define o valor de mercado
            return true;
        }
        /// <summary>
        /// Remove o valor de mercado da pessoa
        /// </summary>
        public bool RemoverValorMercado(Clube clube, Pessoa pessoa)          // remove valor de mercado da pessoa
        {
            if (clube == null || pessoa == null)              // se o clube ou a pessoa nao existirem
                return false;

            return valoresMercadoPorClube[clube].Remove(pessoa);
        }
        /// <summary>
        /// Devolve o valor de mercado da pessoa
        /// </summary>
        public float ObterValorMercado(Clube clube, Pessoa pessoa)    // obtem valor de mercado de uma pessoa
        {
            if (clube == null || pessoa == null)          // se o clube ou a pessoa nao existirem
                return 0f;

            if (!valoresMercadoPorClube[clube].ContainsKey(pessoa))        // nao existe a pessoa nos valores de mercado
                return 0f;

            return valoresMercadoPorClube[clube][pessoa];
        }

        #endregion

        #region Persistência
        /// <summary>
        /// Guarda as financas dos clubes em ficheiro
        /// </summary>
        public bool GuardarFinancas(string ficheiro)     // guarda as financas dos clubes
        {
            try
            {
                using (FileStream fs = new FileStream(ficheiro, FileMode.Create))   // abre ou cria o ficheiro
                {
                    BinaryFormatter bf = new BinaryFormatter();           // em binario
                    bf.Serialize(fs, salariosPorClube);            // guarda salarios por clube
                    bf.Serialize(fs, valoresMercadoPorClube);      // guarda valores de mercado por clube
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Abre e lê as finanças em ficheiro de um clube
        /// </summary>
        public bool LerFinancas(string ficheiro)    // le as financas dos clubes
        {
            if (!File.Exists(ficheiro))    // se o ficheiro nao existir
                return false;

            try
            {
                using (FileStream fs = new FileStream(ficheiro, FileMode.Open))    // abre o ficheiro
                {
                    BinaryFormatter bf = new BinaryFormatter();           // em binario

                    salariosPorClube.Clear();                      // limpa os dicionarios
                    valoresMercadoPorClube.Clear();

                    var sal = (Dictionary<Clube, Dictionary<Pessoa, float>>)bf.Deserialize(fs);
                    var mercado = (Dictionary<Clube, Dictionary<Pessoa, float>>)bf.Deserialize(fs);

                    foreach (var s in sal)                         // copia os dados lidos
                        salariosPorClube.Add(s.Key, s.Value);

                    foreach (var v in mercado)
                        valoresMercadoPorClube.Add(v.Key, v.Value);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}