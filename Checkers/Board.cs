using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Checkers
{
    public partial class Board : UserControl
    {
        Image image_square_dark = (Image)Properties.Resources.ResourceManager.GetObject("square_dark");
        Image image_square_light = (Image)Properties.Resources.ResourceManager.GetObject("square_light");
        Image image_piece_dark = (Image)Properties.Resources.ResourceManager.GetObject("piece_dark");
        Image image_piece_light = (Image)Properties.Resources.ResourceManager.GetObject("piece_light");
        Image image_highlight = (Image)Properties.Resources.ResourceManager.GetObject("highlight_2");

        Square[,] squares = new Square[8, 8];

        Square current_square_hovered;
        Square current_square_selected;

        Point current_mouse_position;

        int square_size = 64;
        int piece_size = 48;
        int piece_offset = (64 - 48) / 2;

        public Board()
        {
            InitBoard();
            InitializeComponent();
        }

        private void InitBoard()
        {
            //Init Squares-Array:
            bool is_light = true;
            for (int x = 0; x < squares.GetLength(0); x++)
            {
                for (int y = 0; y < squares.GetLength(1); y++)
                {
                    squares[x, y] = new Square(new Point(x, y), is_light);

                    if (!is_light)
                    {
                        if (y >= 0 && y <= 2)
                        {
                            squares[x, y].piece = new Piece(false);

                        }
                        else if (y >= 5 && y <= 7)
                        {
                            squares[x, y].piece = new Piece(true);
                        }
                    }

                    is_light = !is_light;
                }
                is_light = !is_light;
            }
        }

        private void Board_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            int square_pos_x;
            int square_pos_y;

            Font debug_font = new Font("Arial", 10);
            SolidBrush debug_brush = new SolidBrush(Color.Red);

            foreach (Square square in squares)
            {
                square_pos_x = square.pos.X * square_size;
                square_pos_y = square.pos.Y * square_size;

                //Draw Square:
                g.DrawImage(
                    square.is_light ? image_square_light : image_square_dark,
                    square_pos_x, square_pos_y,
                    square_size, square_size);

                if (square.piece != null)
                {
                    //Draw Piece:
                    g.DrawImage(
                        square.piece.is_light ? image_piece_light : image_piece_dark,
                        square_pos_x + piece_offset, square_pos_y + piece_offset,
                        piece_size, piece_size);
                }

                //Hovered Square:
                if (current_square_hovered != null)
                {
                    g.DrawImage(
                        image_highlight,
                        current_square_hovered.pos.X * square_size, current_square_hovered.pos.Y * square_size,
                        square_size, square_size);
                }

                //Selected Piece:
                if (current_square_selected != null && current_square_selected.piece != null)
                {
                    g.DrawImage(
                        current_square_selected.piece.is_light ? image_piece_light : image_piece_dark,
                        current_mouse_position.X - piece_size / 2, current_mouse_position.Y - piece_size / 2,
                        piece_size, piece_size);
                }

                //Draw Debug-Text:
                //g.DrawString(square.pos.ToString(), debug_font, debug_brush, square_pos_x, square_pos_y);

            }

        }

        private void Board_MouseMove(object sender, MouseEventArgs e)
        {
            Square temp = current_square_hovered;
            current_mouse_position = e.Location;
            current_square_hovered = GetSquareFromPosition(e.X, e.Y);

            if (temp != current_square_hovered || current_square_selected != null)
            {
                Invalidate();
            }
        }

        private void Board_MouseLeave(object sender, EventArgs e)
        {
            current_square_hovered = null;
            Invalidate();
        }

        private void Board_MouseDown(object sender, MouseEventArgs e)
        {
            current_mouse_position = e.Location;
            current_square_selected = GetSquareFromPosition(e.X, e.Y);
            Invalidate();
        }

        private void Board_MouseUp(object sender, MouseEventArgs e)
        {
            if (current_square_hovered != null && current_square_hovered.piece == null && current_square_selected != null)
            {
                Piece temp = current_square_selected.piece;
                current_square_selected.piece = null;
                current_square_hovered.piece = temp;
            }

            current_square_selected = null;
            Invalidate();
        }

        private Square GetSquareFromPosition(int x, int y)
        {
            int pos_x = x / square_size;
            int pos_y = y / square_size;

            foreach (Square square in squares)
            {
                if (square.pos.X == pos_x && square.pos.Y == pos_y)
                {
                    return square;
                }
            }

            return null;
        }

    }
}
