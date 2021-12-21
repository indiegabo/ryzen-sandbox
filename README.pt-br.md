<p align="right">
  Read in <a href="https://github.com/indiegabo/ryzen-sandbox">English</a>
</p>

# Ryzen Sandbox - Estudando desenvolvimento de jogos 2D na Unity

Esse projeto é um sandbox 2D de plataforma criado para testar e estudar funcionalidades usando a Unity. Sinta-se a vontade para testar.

![Ryzen Running Animation](https://img.itch.zone/aW1hZ2UvOTA2NjA3LzUxMjExMTAuZ2lm/original/pxapC%2B.gif)

Vejo que já conheceu o Ryzen, nosso arqueiro arcano extremamente preciso que nunca erra. Ao menos é assim que ele gosta de ser chamado. Abafa... Deixa eu te contar mais sobre o projeto:

## Funcionalidades que já temos

Aqui estão algumas funcionalidades que já implementamos:

###### Geral

- [Unity Input System](https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/manual/QuickStartGuide.html)
- Mudança de estado das animações através de script para escapar do inferno que poder vir a ser o Animator.
- Sistema de controle de personagem desacoplado, delegando responsabilidades para facilitar possível escalonamento
- Camera Pixel Perfect
- Feedback visual para o "Power Shooting" através de Slider do Canvas
- Eventos do personagem preparados para serem enviados. Atualmente se o Ryzen iniciar um pulo, haverá um feedback visual do evento através de um diamante no canto direito superior da tela piscar.

  **Novidade**

- CineMachine utilizado para que a câmera siga o Ryzen
- O cenário agora é composto por várias camadas
- O cenário agora está com efeito parallax aplicado a ele.

###### Ryzen (Arqueiro)

- Tempo de "carregamento de tiro"
- "Power Shooting", ou tiro mais poderoso, caso pressione o botão de ataque por dado período mínimo de tempo
- Flecha sendo instanciada e destrúida após detecção de colisão
- Animações dos estados Idle, Running, Loading Shoot, Shoot, Ascendinga e Descending.
- Ryzen agora pode rolar (dash). Porém, apenas se estiver no chão.
- Caso o botão de Ataque primário seja pressionado durante um pulo ou dash (e continuar pressionado ao fim da ação) ele automaticamente engajará em combate.
- Pulos e Rolagens cancelam o ataque atual.

  **Novidade**

- Tanto a ação de pulo quanto a ação de rolamento do Ryzen disparam eventos que podem ser capturados por qualquer outra entidade do jogo.

###### Cenário

## Material Utilizado

Muito obrigado e minha imensa recomendação aso artistas aqui listados. Vocês são anjos fornecendo
material para nós que somos loucos por código e precisamos testar as coisas. Sério, muito obrigado!

- [Achane Archer](https://astrobob.itch.io/arcane-archer) por astrobob
- [Free Pixel Art Forest](https://edermunizz.itch.io/free-pixel-art-forest) por edermunizz

## Versão da Unity

Testado na [2020.3.25f1 LTS](https://unity3d.com/pt/unity/whats-new/2020.3.25)

## Como me encontrar

- Junte-se ao nosso amigável servidor no [discord](https://discord.gg/uvgWxNPk)
- Streamando na [Twitch](https://twitch.tv/indiegabo_dev)
- [Instagram](https://instagram.com/indiegabo)
- [Twitter](https://twitter.com/indiegabo)
