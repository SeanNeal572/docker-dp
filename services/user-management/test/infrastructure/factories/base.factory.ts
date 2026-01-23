interface Factory<T> {
  build(): T
  build(amount: number): T[]
  withProps(props: Partial<T>): Factory<T>
  omit<K extends keyof T>(keys: ReadonlyArray<K>): Factory<Omit<T, K>>
}
export function baseFactory<T extends object>(baseBuild: () => T): Factory<T> {
  function build(): T;
  function build(amount: number): T[];
  function build(amount?: number) {
    return typeof amount === 'number' ? Array.from({ length: amount }).map(() => baseBuild()) : baseBuild()
  }

  return {
    build,
    withProps(props) {
      return baseFactory(() => ({
        ...baseBuild(),
        ...props,
      }))
    },
    omit<K extends keyof T>(keys: ReadonlyArray<K>) {
      return baseFactory(() => {
        const entries = Object.entries(baseBuild())
          .filter(([key]) => !keys.includes(key as K))
        return Object.fromEntries(entries)
      }) as Factory<Omit<T, K>>
    }
  }
}
