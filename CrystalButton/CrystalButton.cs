using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrystalButton
{
    /// <summary>
    /// 表示 Windows 的按钮控
    /// </summary>
    [Description("表示 Windows 的按钮控件"), DefaultEvent("Click"), ToolboxBitmap(typeof(System.Windows.Forms.Button))]
    public class Button : Control
    {
        public Button()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.Selectable, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
            _fadeIn.Interval = 30;
            _fadeOut.Interval = 30;
            _fadeIn.Tick += FadeIn_Tick;
            _fadeOut.Tick += FadeOut_Tick;
        }

        /// <summary>
        /// 淡出
        /// </summary>
        private void FadeOut_Tick(object sender, EventArgs e)
        {
            if (ButtonStyle == Style.Flat)
            {
                _glowAlpha = 0;
            }
            if (_glowAlpha - 30 <= 0)
            {
                _glowAlpha = 0;
                _fadeOut.Stop();
            }
            else
            {
                _glowAlpha -= 30;
            }
            Invalidate();
        }

        /// <summary>
        /// 淡入
        /// </summary>
        private void FadeIn_Tick(object sender, EventArgs e)
        {
            if (ButtonStyle == Style.Flat)
            {
                _glowAlpha = 0;
            }
            if (_glowAlpha + 30 >= 255)
            {
                _glowAlpha = 255;
                _fadeIn.Stop();
            }
            else
            {
                _glowAlpha += 30;
            }
            Invalidate();
        }

        private readonly Color[] _colorArray =
        {
            Color.White, Color.FromArgb(172, 168, 153), Color.White,
            Color.FromArgb(236, 233, 216)
        };

        private float _radius = 3;
        private Style _mButtonStyle = Style.Default;
        private State _mButtonState = State.None;
        private readonly Timer _fadeIn = new Timer();
        private readonly Timer _fadeOut = new Timer();
        private int _glowAlpha;
        private ContentAlignment _mTextAlign = ContentAlignment.MiddleCenter;
        private ContentAlignment _mImageAlign = ContentAlignment.BottomCenter;
        private Size _mImageSize = new Size(24, 24);
        private Image _mImage;
        private Image _backImage;

        /// <summary>
        /// 高亮颜色
        /// </summary>
        [Category("Appearance"), Description("高亮颜色"), DefaultValue(typeof(Color), "White"), Browsable(true)]
        public Color LightColor
        {
            set
            {
                _colorArray[0] = value;
                Invalidate();
            }
            get { return _colorArray[0]; }
        }

        /// <summary>
        /// 底色
        /// </summary>
        [Category("Appearance"), Description("底色"), DefaultValue(typeof(Color), "172, 168, 153"), Browsable(true)]
        public Color PrimaryColor
        {
            set
            {
                _colorArray[1] = value;
                Invalidate();
            }
            get { return _colorArray[1]; }
        }

        /// <summary>
        /// 亮点颜色
        /// </summary>
        [Category("Appearance"), Description("亮点颜色"), DefaultValue(typeof(Color), "White"), Browsable(true)]
        public Color GlowColor
        {
            set
            {
                _colorArray[2] = value;
                Invalidate();
            }
            get { return _colorArray[2]; }
        }

        /// <summary>
        /// 基本色
        /// </summary>
        [Category("Appearance"), Description("基本色"), DefaultValue(typeof(Color), "236, 233, 216"), Browsable(true)]
        public Color BaseColor
        {
            set
            {
                _colorArray[3] = value;
                Invalidate();
            }
            get { return _colorArray[3]; }
        }

        /// <summary>
        /// 角的度数
        /// </summary>
        [Category("Appearance"), Description("角的度数"), DefaultValue(typeof(float), "8"), Browsable(true)]
        public float CornerRadius
        {
            set
            {
                _radius = value;
                Invalidate();
            }
            get { return _radius; }
        }

        /// <summary>
        /// 角的度数
        /// </summary>
        [Category("Appearance"), Description("角的度数"), DefaultValue(typeof(Style), "Default"), Browsable(true)]
        public Style ButtonStyle
        {
            get { return _mButtonStyle; }
            set
            {
                _mButtonStyle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// 按钮文本的对其方式
        /// </summary>
        [Category("Text"), Description("按钮文本的对其方式"), DefaultValue(typeof(Style), "MiddleCenter"), Browsable(true)]
        public ContentAlignment TextAlign
        {
            get { return _mTextAlign; }
            set
            {
                _mTextAlign = value;
                Invalidate();
            }
        }

        /// <summary>
        /// 图片的对齐方式
        /// </summary>
        [Category("图像"), Description("图片的对齐方式"), DefaultValue(typeof(ContentAlignment), "MiddleLeft"),
         Browsable(true)]
        public ContentAlignment ImageAlign
        {
            set
            {
                _mImageAlign = value;
                Invalidate();
            }
            get { return _mImageAlign; }
        }

        /// <summary>
        /// 图片的高度和宽度
        /// </summary>
        [Category("图像"), Description("图片的高度和宽度"), DefaultValue(typeof(ContentAlignment), "24,24"), Browsable(true)]
        public Size ImageSize
        {
            set
            {
                _mImageSize = value;
                Invalidate();
            }
            get { return _mImageSize; }
        }

        /// <summary>
        /// 图片
        /// </summary>
        [Category("图像"), Description("图片"), DefaultValue(null), Browsable(true)]
        public Image Image
        {
            set
            {
                _mImage = value;
                Invalidate();
            }
            get { return _mImage; }
        }

        [Category("Appearance"), Description("背景图"), DefaultValue(null), Browsable(true)]
        public Image BackImage
        {
            set
            {
                _backImage = value;
                Invalidate();
            }
            get { return _backImage; }
        }

        /// <summary>
        /// 获取绘制区域路径
        /// </summary>
        /// <param name="r">区域</param>
        /// <param name="r1">角1度数</param>
        /// <param name="r2">角2度数</param>
        /// <param name="r3">角3度数</param>
        /// <param name="r4">角4度数</param>
        /// <returns></returns>
        private GraphicsPath RoundRect(RectangleF r, float r1, float r2, float r3, float r4)
        {
            float x = r.X, y = r.Y, w = r.Width, h = r.Height;
            var gp = new GraphicsPath();
            gp.AddBezier(x, y + r1, x, y, x + r1, y, x + r1, y);
            gp.AddLine(x + r1, y, x + w - r2, y);
            gp.AddBezier(x + w - r2, y, x + w, y, x + w, y + r2, x + w, y + r2);
            gp.AddLine(x + w, y + r2, x + w, y + h - r3);
            gp.AddBezier(x + w, y + h - r3, x + w, y + h, x + w - r3, y + h, x + w - r3, y + h);
            gp.AddLine(x + w - r3, y + h, x + r4, y + h);
            gp.AddBezier(x + r4, y + h, x, y + h, x, y + h - r4, x, y + h - r4);
            gp.AddLine(x, y + h - r4, x, y + r1);
            return gp;
        }

        /// <summary>
        /// 获取绘制文本的方式
        /// </summary>
        /// <returns></returns>
        private StringFormat StringFormatAlignment()
        {
            var sf = new StringFormat();
            switch (TextAlign)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.TopCenter:
                case ContentAlignment.TopRight:
                    sf.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.MiddleRight:
                    sf.LineAlignment = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomLeft:
                case ContentAlignment.BottomCenter:
                case ContentAlignment.BottomRight:
                    sf.LineAlignment = StringAlignment.Far;
                    break;
            }
            switch (TextAlign)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.BottomLeft:
                    sf.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopCenter:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.BottomCenter:
                    sf.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.TopRight:
                case ContentAlignment.MiddleRight:
                case ContentAlignment.BottomRight:
                    sf.Alignment = StringAlignment.Far;
                    break;
            }
            return sf;
        }

        /// <summary>
        /// 绘制外部
        /// </summary>
        /// <param name="g"></param>
        private void DrawOuterStroke(Graphics g)
        {
            if (ButtonStyle == Style.Flat && _mButtonState == State.None)
            {
                return;
            }
            Rectangle r = ClientRectangle;
            r.Width -= 1;
            r.Height -= 1;
            using (GraphicsPath rr = RoundRect(r, CornerRadius, CornerRadius, CornerRadius, CornerRadius))
            {
                using (var p = new Pen(PrimaryColor))
                {
                    g.DrawPath(p, rr);
                }
            }
        }

        /// <summary>
        /// 绘制内部
        /// </summary>
        /// <param name="g"></param>
        private void DrawInnerStroke(Graphics g)
        {
            if (ButtonStyle == Style.Flat && _mButtonState == State.None)
            {
                return;
            }
            Rectangle r = ClientRectangle;
            r.X++;
            r.Y++;
            r.Width -= 3;
            r.Height -= 3;
            using (GraphicsPath rr = RoundRect(r, CornerRadius, CornerRadius, CornerRadius, CornerRadius))
            {
                using (var p = new Pen(LightColor))
                {
                    g.DrawPath(p, rr);
                }
            }
        }

        /// <summary>
        /// 绘制背景
        /// </summary>
        /// <param name="g"></param>
        private void DrawBackground(Graphics g)
        {
            if (ButtonStyle == Style.Flat && _mButtonState == State.None)
            {
                return;
            }
            int alpha = (_mButtonState == State.Pressed) ? 204 : 127;
            Rectangle r = ClientRectangle;
            r.Width--;
            r.Height--;
            using (GraphicsPath rr = RoundRect(r, CornerRadius, CornerRadius, CornerRadius, CornerRadius))
            {
                using (var sb = new SolidBrush(BaseColor))
                {
                    g.FillPath(sb, rr);
                }
                SetClip(g);
                if (BackImage != null)
                {
                    g.DrawImage(BackImage, ClientRectangle);
                }
                g.ResetClip();
                using (var sb = new SolidBrush(Color.FromArgb(alpha, PrimaryColor)))
                {
                    g.FillPath(sb, rr);
                }
            }
        }

        /// <summary>
        /// 绘制高亮
        /// </summary>
        /// <param name="g"></param>
        private void DrawHighlight(Graphics g)
        {
            if (ButtonStyle == Style.Flat && _mButtonState == State.None)
            {
                return;
            }
            int alpha = (_mButtonState == State.Pressed) ? 60 : 150;
            var rect = new Rectangle(0, 0, Width, Height / 2);
            using (GraphicsPath r = RoundRect(rect, CornerRadius, CornerRadius, 0, 0))
            {
                using (var lg = new LinearGradientBrush(r.GetBounds(),
                    Color.FromArgb(alpha, LightColor),
                    Color.FromArgb(alpha / 3, LightColor),
                    LinearGradientMode.Vertical))
                {
                    g.FillPath(lg, r);
                }
            }
        }

        /// <summary>
        /// 绘制亮点
        /// </summary>
        /// <param name="g"></param>
        private void DrawGlow(Graphics g)
        {
            if (_mButtonState == State.Pressed)
            {
                return;
            }
            SetClip(g);
            using (var glow = new GraphicsPath())
            {
                glow.AddEllipse(-5, Height / 2 - 10, Width + 11, Height + 11);
                using (var gl = new PathGradientBrush(glow))
                {
                    gl.CenterColor = Color.FromArgb(_glowAlpha, GlowColor);
                    gl.SurroundColors = new[] { Color.FromArgb(0, GlowColor) };
                    g.FillPath(gl, glow);
                }
            }
            g.ResetClip();
        }

        /// <summary>
        /// 绘制剪辑区域
        /// </summary>
        /// <param name="g"></param>
        private void SetClip(Graphics g)
        {
            Rectangle r = ClientRectangle;
            r.X++;
            r.Y++;
            r.Width -= 3;
            r.Height -= 3;
            using (GraphicsPath rr = RoundRect(r, CornerRadius, CornerRadius, CornerRadius, CornerRadius))
            {
                g.SetClip(rr);
            }
        }

        /// <summary>
        /// 绘制文本
        /// </summary>
        /// <param name="g"></param>
        private void DrawText(Graphics g)
        {
            StringFormat sf = StringFormatAlignment();
            var s = g.MeasureString(Text, Font);
            var x = (int)((Width - s.Width - 1) / 2);
            var y = (int)((Height - s.Height - 1) / 3 * 2);
            var r = new Rectangle(x, y, (int)s.Width + 1, (int)s.Height + 1);
            g.DrawString(Text, Font, new SolidBrush(ForeColor), r, sf);
        }

        /// <summary>
        /// 绘制图片
        /// </summary>
        /// <param name="g"></param>
        private void DrawImage(Graphics g)
        {
            if (Image == null)
            {
                return;
            }
            var r = new Rectangle(8, 8, ImageSize.Width, ImageSize.Height);
            switch (ImageAlign)
            {
                case ContentAlignment.TopCenter:
                    r = new Rectangle(Width / 2 - ImageSize.Width / 2, 8, ImageSize.Width, ImageSize.Height);
                    break;
                case ContentAlignment.TopRight:
                    r = new Rectangle(Width - 8 - ImageSize.Width, 8, ImageSize.Width, ImageSize.Height);
                    break;
                case ContentAlignment.MiddleLeft:
                    r = new Rectangle(8, Height / 2 - ImageSize.Height / 2, ImageSize.Width, ImageSize.Height);
                    break;
                case ContentAlignment.MiddleCenter:
                    r = new Rectangle(Width / 2 - ImageSize.Width / 2, Height / 2 - ImageSize.Height / 2, ImageSize.Width,
                        ImageSize.Height);
                    break;
                case ContentAlignment.MiddleRight:
                    r = new Rectangle(Width - 8 - ImageSize.Width, Height / 2 - ImageSize.Height / 2, ImageSize.Width,
                        ImageSize.Height);
                    break;
                case ContentAlignment.BottomLeft:
                    r = new Rectangle(8, Height - 8 - ImageSize.Height, ImageSize.Width, ImageSize.Height);
                    break;
                case ContentAlignment.BottomCenter:
                    r = new Rectangle(Width / 2 - ImageSize.Width / 2, Height - 8 - ImageSize.Height, ImageSize.Width,
                        ImageSize.Height);
                    break;
                case ContentAlignment.BottomRight:
                    r = new Rectangle(Width - 8 - ImageSize.Width, Height - 8 - ImageSize.Height, ImageSize.Width,
                        ImageSize.Height);
                    break;
            }
            g.DrawImage(Image, r);
        }

        /// <summary>
        /// 重绘按钮
        /// </summary>
        /// <param name="pevent"></param>
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            DrawBackground(pevent.Graphics);
            DrawHighlight(pevent.Graphics);
            DrawImage(pevent.Graphics);
            DrawText(pevent.Graphics);
            DrawGlow(pevent.Graphics);
            DrawOuterStroke(pevent.Graphics);
            DrawInnerStroke(pevent.Graphics);
        }

        /// <summary>
        /// 鼠标移入
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseEnter(EventArgs e)
        {
            _mButtonState = State.Hover;
            _fadeOut.Stop();
            _fadeIn.Start();
            base.OnMouseEnter(e);
        }

        /// <summary>
        /// 鼠标移出
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeave(EventArgs e)
        {
            _mButtonState = State.None;
            if (_mButtonStyle == Style.Flat)
            {
                _glowAlpha = 0;
            }
            _fadeIn.Stop();
            _fadeOut.Start();
            base.OnMouseLeave(e);
        }

        /// <summary>
        /// 鼠标按下
        /// </summary>
        /// <param name="mevent"></param>
        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            if (mevent.Button == MouseButtons.Left)
            {
                _mButtonState = State.Pressed;
                if (_mButtonStyle != Style.Flat)
                {
                    _glowAlpha = 255;
                }
                _fadeIn.Stop();
                _fadeOut.Stop();
                Invalidate();
            }
            base.OnMouseDown(mevent);
        }

        /// <summary>
        /// 鼠标弹起
        /// </summary>
        /// <param name="mevent"></param>
        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            if (mevent.Button == MouseButtons.Left)
            {
                _mButtonState = State.Hover;
                _fadeIn.Stop();
                _fadeOut.Stop();
                Invalidate();
            }
            base.OnMouseUp(mevent);
        }

        /// <summary>
        /// 按钮变化
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            Rectangle r = ClientRectangle;
            r.X -= 1;
            r.Y -= 1;
            r.Width += 2;
            r.Height += 2;
            using (GraphicsPath rr = RoundRect(r, CornerRadius, CornerRadius, CornerRadius, CornerRadius))
            {
                Region = new Region(rr);
            }
            base.OnResize(e);
        }

        /// <summary>
        /// 鼠标活动类别
        /// </summary>
        public enum State
        {
            /// <summary>
            /// 正常状态
            /// </summary>
            None,
            /// <summary>
            /// 鼠标悬浮状态
            /// </summary>
            Hover,
            /// <summary>
            /// 鼠标按下
            /// </summary>
            Pressed
        }

        /// <summary>
        /// 绘制样式
        /// </summary>
        public enum Style
        {
            /// <summary>
            /// 只画背景的鼠标
            /// </summary>
            Default,
            /// <summary>
            /// 绘制按钮作为正常
            /// </summary>
            Flat
        };
    }
}
