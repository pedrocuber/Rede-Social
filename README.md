Documento de Requisitos de Software

 Auto Car

Sumário


1.	Introdução

1.1 Propósito

O propósito dessa rede social é que os usuários compartilhem os seus carros.

	1.2 Escopo

O sistema deve permitir a publicação de textos e imagens ao usuários para possam compartilhar seus carros.

O sistema não oferece acesso pela Internet aos usuários.


	
2.	Descrição do Sistema

O sistema a ser modelado tem como objetivo ser uma rede social que permite os usuários a criarem um perfil, um post e a comentarem.


3.	Levantamento de Requisitos
3.1 Atores

Atendente: realiza as principais funcionalidades do sistema como cadastro de publicações, cadastro de professores e alunos, empréstimos e reservas de publicações.

	Administrador: realiza o cadastro e atualizações de novas bibliotecas.
3.2 Requisitos funcionais

[RF-01] Cadastrar Usuário
[RF-02] Cadastrar Perfil
[RF-03] Criar Postagem
[RF-04] Criar Comentário
[RF-05] Upload de imagem de perfil
[RF-06] Upload de imagem na postagem
[RF-07] Edição de postagem
[RF-08] Deleção de postagem
[RF-09] Criação de comentário
[RF-10] Edição de comentário

3.3 Requisitos não funcionais

[RNF-01] Acessibilidade
[RNF-02] Backups semanais
[RNF-03] Oferecer um tempo de resposta abaixo de 15 segundos
[RNF-04] Oferecer capacidade para imagens de grandes tamanhos
[RNF-05] Oferecer capacidade de upload de vídeo

3.5 Descrição dos Casos de Uso

[RF-03] Criar Postagem

Atores: Usuário.

Pré-condições: O usuário deve estar logado em sua conta e ter criado o seu perfil.

Fluxo básico:


1.	O sistema solicita o e-mail e a senha do usuário.
2.	O sistema solicita para que o e-mail do usuário seja validado.
3.	O sistema pede o e-mail e senha do usuário para realizar o login.
4.	O usuário cria o seu perfil com seu nome e foto.
5.	O usuário cria um post com seu Id do perfil, Data da Postagem, Texto do post e uma imagem.
6.	O usuário pode criar um comentário.

Fluxos alternativos:


1.	Usuário cadastrado, porém, sem logar.
2.	Erro no cadastro do Usuário.

Regras de validação:


•	Validar e-mail.

Pós-condições:


•	Criar a conta do Usuário.

4. Diagrama de Classes




5. Definição do Projeto

Serão utilizadas as seguintes ferramentas para o desenvolvimento do sistema:

Microsoft Azure: SQL Relacional (apenas para a apresentação) e Blob
Microsoft .Net versão 6
Microsoft Entity Framework
Microsoft Identity
Microsoft Visual Studio 2022
Microsoft SQL Server Express
Microsoft C# versão 8
Microsoft Web Server IIS

O projeto utiliza o padrão de projeto MVC e API.
6. Cronograma da evolução do projeto

Data	Etapa
Out/2022	Definição do mini-mundo.
Nov/2022	Levantamento dos RFs e RNFs, Diagrama de Casos de Uso e Descrição dos Casos de Uso.
Dez/2022	Início do desenvolvimento do Documento de Requisitos de Software e Apresentação do PB

Referências

MAIA, L.P., Mini-mundo da Biblioteca, Infnet, 2022. Consultado em 22/03/2022 no link https://docs.google.com/document/d/1HI2WjoT5sXmdaegDQ6mXknOfIt88iCqlGuPtSqJwKL4/edit?usp=sharing
