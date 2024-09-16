namespace JogoDaVelha
{
    public partial class Form1 : Form
    {

        int Xplayer = 0, Oplayer = 0, empatesPontos = 0, rodadas = 0;
        bool turno = true, jogo_final = false;
        string[] texto = new string[9];

        public Form1()
        {
            InitializeComponent();
        }

        private void xpontos_Click(object sender, EventArgs e)
        {

        }

        private void empates_Click(object sender, EventArgs e)
        {

        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int buttonIndex = btn.TabIndex;

            if (btn.Text == "" && jogo_final == false)
            {
                if (turno)
                {
                    btn.Text = "x";
                    texto[buttonIndex] = btn.Text;
                    rodadas++;
                    turno = !turno;
                    Checagem(1);
                }
                else
                {
                    btn.Text = "O";
                    texto[buttonIndex] = btn.Text;
                    rodadas++;
                    turno = !turno;
                    Checagem(2);

                }
            }
        }


        void Vencedor(int PlayerGanhador)
        {
            jogo_final = true;

            if (PlayerGanhador == 1)
            {

                Xplayer++;
                xpontos.Text = Convert.ToString(Xplayer);
                MessageBox.Show("Jogador X ganhou");
                turno = true;
            }
            else
            {

                Oplayer++;
                Opontos.Text = Convert.ToString(Oplayer);
                MessageBox.Show("Jogador O ganhou");
                turno = false;
            }
        }

        void Checagem(int checagemPlayer)
        {
            string suporte = "";

            if (checagemPlayer == 1)
            {
                suporte = "x";
            }
            else
            {
                suporte = "O";
            }

            for (int horizontal = 0; horizontal < 8; horizontal += 3)
            {
                if (suporte == texto[horizontal])
                {     // Checar na horizontal 
                    if (texto[horizontal] == texto[horizontal + 1] && texto[horizontal] == texto[horizontal + 2])
                    {
                        Vencedor(checagemPlayer);
                        return;

                        // final de chacagem 
                    }
                }
            }



            for (int vertical = 0; vertical < 3; vertical++)
            {
                if (suporte == texto[vertical])
                {     // Checar na vertical
                    if (texto[vertical] == texto[vertical + 3] && texto[vertical] == texto[vertical + 6])
                    {
                        Vencedor(checagemPlayer);
                        return;



                    }
                }
            }

            // Checar na diagonal primaria 

            if (texto[0] == suporte)
            {
                if (texto[0] == texto[4] && texto[0] == texto[8])
                {
                    Vencedor(checagemPlayer);
                    return;
                }
            }




            if (texto[2] == suporte)
                if (texto[2] == texto[4] && texto[2] == texto[6])
                {
                    Vencedor(checagemPlayer);
                    return;
                } // diagonal secundario


            if (rodadas == 9 && jogo_final == false)
            {
                empatesPontos++;
                empates.Text = Convert.ToString(empatesPontos);


                MessageBox.Show("Empate!");
                jogo_final = true;
                return;
            }

        }


















        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            btn.Text = "";
            btn1.Text = "";
            btn2.Text = "";
            btn3.Text = "";
            btn4.Text = "";
            btn5.Text = "";
            btn6.Text = "";
            btn7.Text = "";
            btn8.Text = "";


            rodadas = 0;
            jogo_final = false;
            for( int i = 0; i < 9; i++ )
            {
                texto[i] = "";
            }

        }
    }
}

