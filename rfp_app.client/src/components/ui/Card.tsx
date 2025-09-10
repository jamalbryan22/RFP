import { ReactNode } from "react";
export function Card({ children }: { children: ReactNode }) {
  return <div className="rounded-[--radius] border bg-[--color-surface] shadow-sm">{children}</div>;
}
export function CardHeader({ children }: { children: ReactNode }) {
  return <div className="px-4 py-3 border-b font-medium">{children}</div>;
}
export function CardContent({ children }: { children: ReactNode }) {
  return <div className="p-4">{children}</div>;
}
