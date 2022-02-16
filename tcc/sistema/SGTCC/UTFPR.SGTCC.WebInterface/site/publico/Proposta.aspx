<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="Proposta.aspx.vb"
    Title="SGTCC - Dúvidas freqüentes sobre a Proposta" Inherits="UTFPR.SGTCC.WebInterface.Proposta" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">

    <br />
    <label class="cssTitulo">O que é uma proposta?</label>
    <br /><br />
    <label class="cssLabel">Uma proposta é um texto que explica de forma clara quais objetivos serão alcançados e quais metas serão
           cumpridas para sealcançar este objetivo. Deve-se também mostrar em qual ambiente este trabalho está inserido e quais as
           vantagens trazidas por este estudo. 
    </label>
    <br /><br />

    <label class="cssTitulo">Qual a próxima data para apresentação de propostas?</label>
    <br /><br />
    <label class="cssLabel">A próxima data para a entrega das propostas é de
           <label class="cssError">27 a 31 de outubro de 2008.</label></label>
           <label class="cssLabel"> As bancas ocorrerão de <label class="cssError">17 a 28 de novembro de 2008.</label>
    </label>
    <br /><br />

    <label class="cssTitulo">Quais os períodos para apresentação de propostas?</label>
    <br /><br />
    <label class="cssLabel">A partir de maio de 2007, as bancas de avaliação de propostas e de defesa de trabalho de diplomação,
            serão realizadas em dois únicos períodos no ano, são eles:
    </label>        
    <ul>
        <li>Para matrícula em trabalho de diplomação em janeiro, com prazo para defesa em novembro do mesmo ano, o aluno
            deverá apresentar a proposta em novembro do ano anterior; 
        </li>
        <li>Para matrícula em trabalho de diplomação em agosto, com prazo para defesa em junho do ano seguinte, o aluno deverá
            apresentar a proposta em junho do mesmo ano; 
        </li>
        <li>O aluno que ultrapassar o período de uma ano estará automaticamente reprovado, tendo que iniciar todo o processo de
            trabalho de diplomação novamene. Somente o orientador tem o direito de cancelar a reprovação automática; 
        </li>
    </ul>
    <div style="background-color: White;">
        <label class="cssTitulo">Qual a pontuação da proposta?</label>
        <br /><br />
        <label class="cssLabel">Com a finalidade de aumentar a qualidade das propostas de trabalho de diplomação, os alunos que
                apresentarem após maio de 2007 estarão sujeitos a uma nova forma de avaliação.
        </label><br />
        <label class="cssLabel">A nova forma de avaliação consiste em dar pesos diferentes as várias etapas do trabalho de diplomação.
                São elas:
        </label><br /><br />
        <label class="cssLabel">- Proposta de Trabalho de Diplomação (peso 3) </label><br />
        <label class="cssLabel">- Cronograma de Desenvolvimento (peso 2) </label><br /> 
        <label class="cssLabel">- Trabalho Final de Diplomação (peso 2) </label><br />
        <label class="cssLabel">- Apresentação do Trabalho Final de Diplomação (peso 1) </label><br />
        <label class="cssLabel">- Produto do Trabalho Final de Diplomação (peso 1) </label><br />
        <label class="cssLabel">- Nota definida pelo professor orientador (peso 1) </label><br />
        <br /><br />
        
        <label class="cssTitulo">Quais os itens que devem ser apresentados?</label> 
        <br /><br />
        <label class="cssLabel">1 - Introdução</label> 
        <br /><br />
        <label class="cssLabel">Como em todo documento, a introdução deve apresentar o documento informando ao leitor o objetivo do
            documento, a área a ser estudada, produtos ou estudos semelhantes e o nome do produto ou estudo a ser detalhado no documento.
        </label>
        <br /><br />

        <label class="cssLabel">2 - Justificativa</label><br /><br /> 
        
        <label class="cssLabel">
        "Nesta seção são descritos, em linhas gerais, o cenário atual do negócio a ser impactado pela aplicação e a abordagem do projeto
         para este cenário, de modo a comunicar seu propósito e importância a todas as pessoas envolvidas. Deve ficar claro por que os
         clientes e usuários finais precisam da solução." <br />
        "Deve-se utilizar o tempo presente para falar do problema atual e tempo futuro para falar da situação do negócio quando a nova
         solução for implantada."<br />
        [baseado nos itens do Image Cup 2007]<br /> 
        Recomenda-se utilizar as seguintes perguntas para este capítulo: 
        </label>
        <ul>
            <li>Qual é o problema?  </li>
            <li>Quem é afetado por este problema?  </li>
            <li>Qual o impacto disto no ambiente estudado?  </li>
            <li>Qual seria a solução? </li>
        </ul>

        <label class="cssLabel">3 - Objetivos Gerais <br /><br />

            Neste capítulo deve ser apresentar de forma clara o foco do estudo. Não confunda objetivo com meta, as metas
            (objetivos específicos)devem ser cumpridas para se chegar ao objetivo - o foco.
        </label>
        <br /><br />
        
        <label class="cssLabel">4 - Objetivos Específicos <br /><br />
            Neste capítulo deve-se listar as funcionalidades do sistema, bem como definir a categoria desta funcionalidade em:
        </label>
        <ul>
            <li>Essencial: requisitos funcionais em que a sua não ocorrência impossibilita o funcionamento do sistema. ex.: cadastro de clientes em um sistema de entrega;  </li>
            <li>Importante: requisitos funcionais em que sua não ocorrência não impossibilita o funcionamento do sistema. ex.: cadastro de estado e cidades em um sistema de entrega;  </li>
            <li>Desejável:requisitos não funcionais. ex.: gerar relatórios em pdf; </li>
        </ul>

        <label class="cssLabel">5 - Limites e Restrições da Solução <br /><br />
            Neste capítulo deve ser apresentado para qual ambiente será desenvolvido a solução ou estudo de caso e quais as
            funcionalidades que não serão implementadas de forma a restringir as cobranças na banca final.
        </label>
        <br /><br />
        
        <label class="cssLabel">6 - Descrição dos Usuários <br /><br />
            Neste capítulo deve ser apresentados os atores que serão envolvidos na solução ou estudo de caso, bem como o papel
            de cada ator.
        </label>
        <br /><br />
        
        <label class="cssLabel">7 - Tecnologias Utilizadas <br /><br />
            Neste capítulo dese ser apresentado as tecnologias, ferramentas, técnicas que serão utilizadas para:
        </label>
        <ul>
            <li>Desenvolvimento; </li>
            <li>Implantação;  </li>
        </ul>
     
        <label class="cssLabel">8 - Arquitetura do Sistema <br /><br />
            Neste capítulo deve ser apresentado:
        </label>
        <ul>
            <li>A arquitetura de hardware utilizada, informando para cada hardware o papel dentro da solução ou estudo de caso proposto;  </li>
            <li>A arquitetura de software utilizada, informando as camadas que serão implementadas e qual o papel dentro da solução ou estudo de caso proposto;  </li>
        </ul>

        <label class="cssLabel">9 - Metodologia de Desenvolvimento <br /><br />
            Neste capítulo deve ser apresentado qual modelo de ciclo de vida será utilizado:
        </label>
            <ul>
                <li>Modelo de ciclo de vida em cascata;  </li>
                <li>Modelo de ciclo de vida iterativo e incremental;  </li>
                <li>Também deve ser informando qual o processo a ser utilizado como modelo e o por que da escolha.  </li>
            </ul>

        <label class="cssLabel">10 - Cronograma Inicial <br /><br />
            Neste capítulo deve ser apresentado qual será a primeira meta a ser cumprida de forma detalhada.
        </label>
        <br /><br />
        
        <label class="cssLabel">11 - Cronograma Geral <br /><br />
            Neste capítulo informar o cronorama geral informando mês e semana de cada tarefa.
        </label>
        <br /><br />
        
        <label class="cssLabel">12 - Refeências Bibliográficas <br /><br /></label>
            
        <label class="cssLabel">13 - Bibliografia <br /><br /></label>
  </div> 

    
</asp:Content> 