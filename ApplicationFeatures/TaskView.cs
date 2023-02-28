using System.Runtime.CompilerServices;
using System.Text;
using WindowsInputLib;
using WindowsInputLib.Native;
using static CornerTaskSwitcher.Models.Win32;

namespace CornerTaskSwitcher.ApplicationFeatures
{
    internal class TaskView : IApplicationFeatures
    {
        private static HookProcess _process;
        private static InputSimulator _inputSimulator;
        private static int _mouseWheelSensitivity;
        private static int m_scrollAmount;

        private static int _scrollAmount
        {
            get => m_scrollAmount;
            set
            {
                int intermediateValue = m_scrollAmount + value;
                if ((intermediateValue > m_scrollAmount && m_scrollAmount >= 0) || 
                    (intermediateValue < m_scrollAmount && m_scrollAmount <= 0))
                    m_scrollAmount = intermediateValue;
                else
                    m_scrollAmount = value;
            }
        }

        public static void Initialize()
        {
            SetHookOnMouseWheel();
            _inputSimulator = new InputSimulator();
            _mouseWheelSensitivity = (120 * 2) - 1;
        }

        public static void Update()
        {
            MSG msg;

            if (GetMessage(out msg, IntPtr.Zero, 0, 0))
            {
                TranslateMessage(ref msg);
                DispatchMessage(ref msg);
            }
        }

        private static void SetHookOnMouseWheel()
        {
            IntPtr module = GetModuleHandleA("user32.dll");
            _process = new HookProcess(MouseHookProcess);

            IntPtr hook = SetWindowsHookEx(WH_MOUSE_LL, _process, module, 0);
        }

        private static unsafe IntPtr MouseHookProcess(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode < 0)
            {
                return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
            }

            ref MSLLHOOKSTRUCT mouseStruct = ref Unsafe.AsRef<MSLLHOOKSTRUCT>((void*)lParam);

            if ((int)wParam == WM_MOUSEWHEEL && isOpenTaskView())
            {
                _scrollAmount = mouseStruct.mouseData >> 16;
                if (_scrollAmount > _mouseWheelSensitivity)
                {
                    SwitchDesktop(VirtualKeyCode.Left);

                    _scrollAmount = 0;
                }
                else if (_scrollAmount < -_mouseWheelSensitivity)
                {
                    SwitchDesktop(VirtualKeyCode.Right);

                    _scrollAmount = 0;
                }
            }

            return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }

        private static bool isOpenTaskView()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr foreground = GetForegroundWindow();

            if (GetWindowText(foreground, Buff, nChars) > 0)
                if (Buff.ToString() == "Представление задач")
                    return true;

            return false;
        }

        private static void SwitchDesktop(VirtualKeyCode virtualKeyCode)
        {
            _inputSimulator.Keyboard.KeyDown(VirtualKeyCode.LControl);
            _inputSimulator.Keyboard.KeyDown(VirtualKeyCode.LWin);
            _inputSimulator.Keyboard.KeyPress(virtualKeyCode);
            _inputSimulator.Keyboard.KeyUp(VirtualKeyCode.LControl);
            _inputSimulator.Keyboard.KeyUp(VirtualKeyCode.LWin);
        }
    }
}
