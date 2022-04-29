alter table prova add if not exists ultima_atualizacao timestamp;
update prova set ultima_atualizacao = inclusao where ultima_atualizacao is null;