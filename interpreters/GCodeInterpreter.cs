﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using g3;

namespace gs
{
    public struct InterpretArgs
    {
        public GCodeLine.LType eTypeFilter;


        public bool HasTypeFilter { get { return eTypeFilter != GCodeLine.LType.Blank; } }

        public static readonly InterpretArgs Default = new InterpretArgs() {
            eTypeFilter = GCodeLine.LType.Blank
        };
    }


    public interface IGCodeInterpreter
    {
        void AddListener(IGCodeListener listener);
        void Interpret(GCodeFile file, InterpretArgs args);
    }

    public interface IGCodeListener
    {
        void Begin();
		void End();

		void BeginTravel();
		void BeginDeposition();

        void LinearMoveToAbsolute2d(Vector2d v);
        void LinearMoveToRelative2d(Vector2d v);
		void ArcToRelative2d(Vector2d pos, double radius, bool clockwise);

		void LinearMoveToAbsolute3d(Vector3d v);
		void LinearMoveToRelative3d(Vector3d v);
    }

}
