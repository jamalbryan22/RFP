import { ButtonHTMLAttributes } from "react";
import clsx from "clsx";

type Props = ButtonHTMLAttributes<HTMLButtonElement> & {
  variant?: "primary" | "outline" | "ghost";
};

export default function Button({ variant="primary", className, ...props }: Props) {
  const base = "inline-flex items-center justify-center rounded-[--radius] px-4 py-2 text-sm font-medium transition focus-visible:outline focus-visible:outline-2 focus-visible:outline-[--color-primary]";
  const styles = {
    primary: "bg-[--color-primary] text-white hover:bg-[--color-primary-600]",
    outline: "border border-slate-300 bg-white hover:bg-slate-50",
    ghost: "hover:bg-slate-100",
  }[variant];
  return <button className={clsx(base, styles, className)} {...props} />;
}
