# FruitShopping

Para executar esse projeto basta iniciar a aplicação, lembre de adicionar tanto o identity server quanto o FruitApi como startup projects
* Execute a aplicação Angular, caso peça instale o componente angular-oauth2-oidc pelo comando npm install angular-oauth2-oidc
* A aplicação deverá criar duas bases de dados uma para identity server (identitydb) e uma para a api (fruishoppingdb) 
* Execute o script load_base no banco de dados fruishoppingdb
* Quando a aplicação solicitar um login basta criar um novo usuário com o seu nome e utilizar normalmente
* Nâo é necessário login para ver os produtos a aplicação deverá solicitar o mesmo a partir de uma compra