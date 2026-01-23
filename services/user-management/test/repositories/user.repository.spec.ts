import { describe, expect, it } from 'vitest'
import { User } from '@/types'
import { connect } from '@/repositories/datasource'
import { userFactory } from '../infrastructure/factories/user.factory'
import { createUser, getUserById, getUsers, removeUser, updateUser } from '@/repositories/user.repository'
import { first } from 'lodash'

const userDetailsFactory = userFactory.omit(['id'])

describe('user.repository', () => {
  describe('getUsers', () => {
    it('should return all users', async () => {
      // Arrange
      const userDetails = userDetailsFactory.build(20)
      const users = await withUsers(userDetails)

      // Act
      const result = await getUsers()

      // Assert
      expect(result).toEqual(users)
    })
  })

  describe('getUserById', () => {
    it('should return user', async () => {
      // Arrange
      const userDetails = userDetailsFactory.build()
      const user = await withUser(userDetails)

      // Act
      const result = await getUserById(user.id)

      // Assert
      expect(result).toEqual(user)
    })
  })

  describe('createUser', () => {
    it('should return all users', async () => {
      // Arrange
      const userDetails = userDetailsFactory.build()

      // Act
      const result = await createUser(userDetails)

      // Assert
      expect(result).toMatchObject(userDetails)
    })
  })

  describe('updateUser', () => {
    it('should return all users', async () => {
      // Arrange
      const userDetails = userDetailsFactory.build()
      const user = await withUser(userDetails)
      const updateDetails = userDetailsFactory.build()

      // Act
      const result = await updateUser({ id: user.id, ...updateDetails })

      // Assert
      expect(result).toMatchObject({ id: user.id, ...updateDetails })
    })
  })

  describe('removeUser', () => {
    it('should return all users', async () => {
      // Arrange
      const userDetails = userDetailsFactory.build()
      const user = await withUser(userDetails)

      // Act
      await removeUser(user.id)
      const result = await connect().table("user").select("*").where({ id: user.id }).first()

      // Assert
      expect(result).toBeUndefined()
    })
  })
})

async function withUsers(users: Omit<User, 'id'>[]) {
  return await connect().table("user").insert(users).returning("*")
}

async function withUser(user: Omit<User, 'id'>) {
  const createdUsers = await connect().table("user").insert(user).returning("*")
  return first(createdUsers)
}
