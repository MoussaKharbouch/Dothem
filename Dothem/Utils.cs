using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dothem
{
    static internal class Utils
    {
         
        static internal class GUI
        {

            static internal void InitializeForm(System.Windows.Forms.Form form)
            {

                form.BackColor = Properties.Settings.Default.BackgroundColor;
                form.ForeColor = Properties.Settings.Default.FontColor;

                StyleLabel(form);
                StyleButton(form);
                StyleLinkLabel(form);

            }

            static private void StyleLabel(System.Windows.Forms.Form form)
            {

                foreach (System.Windows.Forms.Label lbl in form.Controls.OfType<System.Windows.Forms.Label>())
                {

                    float fontSize = lbl.Font?.Size ?? Properties.Settings.Default.NormalTextFont.Size;

                    FontFamily family;
                    FontStyle style;
                    GraphicsUnit unit;
                    byte gdiCharSet;
                    bool gdiVerticalFont;

                    if (lbl.Tag?.ToString() == "Title")
                    {

                        family = Properties.Settings.Default.TitleFont.FontFamily;
                        style = Properties.Settings.Default.TitleFont.Style;
                        unit = Properties.Settings.Default.TitleFont.Unit;
                        gdiCharSet = Properties.Settings.Default.TitleFont.GdiCharSet;
                        gdiVerticalFont = Properties.Settings.Default.TitleFont.GdiVerticalFont;

                    }
                    else
                    {

                        family = Properties.Settings.Default.NormalTextFont.FontFamily;
                        style = Properties.Settings.Default.NormalTextFont.Style;
                        unit = Properties.Settings.Default.NormalTextFont.Unit;
                        gdiCharSet = Properties.Settings.Default.NormalTextFont.GdiCharSet;
                        gdiVerticalFont = Properties.Settings.Default.NormalTextFont.GdiVerticalFont;

                    }

                    lbl.Font = new Font(

                        family,
                        fontSize,
                        style,
                        unit,
                        gdiCharSet,
                        gdiVerticalFont

                    );

                }

            }

            static private void StyleLinkLabel(System.Windows.Forms.Form form)
            {

                foreach (System.Windows.Forms.LinkLabel lbl in form.Controls.OfType<System.Windows.Forms.LinkLabel>())
                {

                    float fontSize = lbl.Font?.Size ?? Properties.Settings.Default.NormalTextFont.Size;

                    FontFamily family;
                    FontStyle style;
                    GraphicsUnit unit;
                    byte gdiCharSet;
                    bool gdiVerticalFont;

                    lbl.LinkColor = Properties.Settings.Default.FontColor;
                    lbl.ActiveLinkColor = Color.DarkBlue;

                    if (lbl.Tag?.ToString() == "Title")
                    {

                        family = Properties.Settings.Default.TitleFont.FontFamily;
                        style = Properties.Settings.Default.TitleFont.Style;
                        unit = Properties.Settings.Default.TitleFont.Unit;
                        gdiCharSet = Properties.Settings.Default.TitleFont.GdiCharSet;
                        gdiVerticalFont = Properties.Settings.Default.TitleFont.GdiVerticalFont;

                    }
                    else
                    {

                        family = Properties.Settings.Default.NormalTextFont.FontFamily;
                        style = Properties.Settings.Default.NormalTextFont.Style;
                        unit = Properties.Settings.Default.NormalTextFont.Unit;
                        gdiCharSet = Properties.Settings.Default.NormalTextFont.GdiCharSet;
                        gdiVerticalFont = Properties.Settings.Default.NormalTextFont.GdiVerticalFont;

                    }

                    lbl.Font = new Font(

                        family,
                        fontSize,
                        style,
                        unit,
                        gdiCharSet,
                        gdiVerticalFont

                    );

                }

            }

            static private void StyleButton(System.Windows.Forms.Form form)
            {

                foreach (Button btn in form.Controls.OfType<Button>())
                {

                    btn.BackColor = Properties.Settings.Default.ButtonBackgroundColor;
                    btn.Font = new Font(btn.Font, FontStyle.Bold);

                }

            }
            static internal void CenterText(System.Windows.Forms.Label lbl)
            {

                lbl.Left = (lbl.Parent.ClientSize.Width - lbl.Width) / 2;

            }

        }

    }

}