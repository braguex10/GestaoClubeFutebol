/*
*	<copyright file="OrcamentoInsuficienteException.cs"
*		Copyright (c) 2025 All Rights Reserved
*	</copyright>
* 	<author>a31508goncalobraga</author>
*	<description></description>
**/


namespace ClubeFutebol.Exceptions
{
    /// <summary>
    /// Explicação de que há falta de orçamento para a execução de um processo
    /// </summary>
    public class OrcamentoInsuficienteException : DominioException
    {
        public OrcamentoInsuficienteException()
            : base("Orçamento insuficiente para a operação.")
        {
        }
    }
}
